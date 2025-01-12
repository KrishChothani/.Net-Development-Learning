using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proj_3.DataBase;
using Proj_3.Models;
using System.Collections;

namespace Proj_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DbServices _dbServices;

        public UserController(DbServices dbServices)
        {
              _dbServices = dbServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = "krish";
            return Ok(user);
        }

    }
}
