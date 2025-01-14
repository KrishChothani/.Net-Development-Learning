using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proj_5.Dto;
using Proj_5.Interfaces;
using Proj_5.Models;

namespace Proj_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserInterface _userInterface;
        private readonly IMapper _mapper;
        public UserController(IUserInterface userInterface, IMapper mapper)
        {
            _userInterface = userInterface;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetAllUser()
        {
            var users = _mapper.Map<List<UserDto>>(_userInterface.GetAllUser());
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUserById(int id)
        {
            Console.WriteLine(id);
            if (!_userInterface.UserExist(id)) return NotFound();
            var user = _mapper.Map<UserDto>(_userInterface.GetUserById(id));

            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserDto userCreate)
        {
            Console.WriteLine(userCreate);
            if (userCreate == null) return BadRequest(ModelState);

            var users = _userInterface.GetAllUser()
                        .Where(c => c.UserName.Trim().ToUpper() == userCreate.UserName.Trim().ToUpper());
            Console.Write(users);
            if (users == null)
            {
                ModelState.AddModelError("", "Owner Already Exist");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(userCreate);

            if (!_userInterface.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Something went Wrong ..");
                return StatusCode(500, ModelState);
            }
            return Ok("User Create SuccessFully");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int id , [FromBody] UserDto updateUser)
        {
            if (id != updateUser.Id) return BadRequest(ModelState);
            if (!_userInterface.UserExist(id)) return NotFound();

            if(!ModelState.IsValid) return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(updateUser);

            if(!_userInterface.UpdateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating the User");
                return StatusCode(500,ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int id) 
        {
            if (!_userInterface.UserExist(id)) return NotFound();

            var user = _userInterface.GetUserById(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if(!_userInterface.DeleteUser(user))
            {
                ModelState.AddModelError("", "Something went wrong while deleting the User");
                return StatusCode(500,ModelState);
            }

            return NoContent();
        }
    }
}
