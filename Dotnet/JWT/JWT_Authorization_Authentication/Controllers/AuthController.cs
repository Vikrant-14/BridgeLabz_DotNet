using JWT_Authorization_Authentication.Interfaces;
using JWT_Authorization_Authentication.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT_Authorization_Authentication.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public string Login([FromBody] LoginRequest obj)
        {
            var token = _authService.Login(obj);

            return token;
        }

        [HttpPost("assignRole")]
        public bool AssignRoleToUser([FromBody] AddUserRole userRole)
        {
            var addedUserRole = _authService.AssignRoleToUser(userRole);
            return addedUserRole;
        }

       
        [HttpPost("addUser")]
        public User AddUser([FromBody] User user)
        {
            var addeduser = _authService.AddUser(user);
            return addeduser;
        }

        [HttpPost("addRole")]
        public Role AddRole([FromBody] Role role)
        {
            var addedRole = _authService.AddRole(role);
            return addedRole;
        }
    }
}
