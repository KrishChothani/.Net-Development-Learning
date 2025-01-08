using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Proj_2.DataBase;
using Proj_2.Models;

namespace Proj_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usercontroller : ControllerBase
    {
        private readonly IMongoCollection<User> _users;
        public Usercontroller(MongoDbServices mongoDbServices)
        {
            _users = mongoDbServices.Database?.GetCollection<User>("user");
        }

        [HttpGet]
        public async Task<IEnumerable<User>> getUser()
        {
            return await _users.Find(FilterDefinition<User>.Empty).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> getUserbyId(string id)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, id);
            var user = _users.Find(filter).FirstOrDefault();
            return user is not null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> createUser(User user)
        {
            await _users.InsertOneAsync(user);
            //return CreatedAtActionResult(nameof(getUserbyId), new { id = user.Id} , user);
            return Ok(user);

        }

        [HttpPut]
        public async Task<ActionResult> updateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, user.Id);
            //var updateduser = Builders<User>.Update.Set(x => x.UserName, user.UserName)
            //                                           .Set(x => x.EmailId, user.EmailId);
            //await _users.UpdateOneAsync(filter, updateduser);
            //return Ok(updateduser);

            //--------------------------------//

            await _users.ReplaceOneAsync(filter, user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteUser(string id)
        {
            var filter = Builders<User>.Filter.Eq(x =>x.Id, id);
            await _users.DeleteOneAsync(filter);
            return Ok();
        }

    }
}
