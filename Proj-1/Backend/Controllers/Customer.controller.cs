using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Models;
using index;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMongoCollection<Customer>? _customers;

        public CustomerController(MongoDBService mongoDBService)
        {
            _customers = mongoDBService.DataBase?.GetCollection<Customer>("customer");
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _customers.Find(FilterDefinition<Customer>.Empty).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(string id)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.Id, id);
            var customer = await _customers.Find(filter).FirstOrDefaultAsync();
            return customer is not null ? Ok(customer) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Customer customer)
        {
            await _customers.InsertOneAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Customer customer)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.Id, customer.Id);
            var result = await _customers.ReplaceOneAsync(filter, customer);

            if (result.ModifiedCount == 0)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.Id, id);
            var result = await _customers.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
