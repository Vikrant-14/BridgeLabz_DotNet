using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System.Runtime.CompilerServices;

namespace ProjectName.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        [HttpPost]
        public IActionResult AddUser(UserML model)
        {
            var result = userBL.AddUser(model);

            if (result != null)
            {
                return Ok(result);
            }
            else {
                return BadRequest("Something went wrong!!!");
            }
        }

        [HttpPost("{name}")]
        public IActionResult EditUser(string name, UserML model)
        {
            var result = userBL.UpdateUser(name, model);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Something went wrong. Cannot update the result!!!");
            }
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            var result = userBL.GetAllUsers();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("NO DATA AVAILABLE");
            }
        }

        [HttpGet("{name}")]
        public IActionResult GetUserByName(string name) 
        {
            var result = userBL.GetUserByName(name);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var result = userBL.DeleteUser(id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No Data Exists To Delete");
            }
        }
    }
}
