using Microsoft.AspNetCore.Mvc;
using Proj_5.Interfaces;
using Proj_5.Models;

namespace Proj_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserInterface _userInterface;
        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUser()
        {
            var users = _userInterface.GetUsers();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(users);

        }
    }
}
