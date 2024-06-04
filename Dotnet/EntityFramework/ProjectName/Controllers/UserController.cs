using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using RepositoryLayer.CustomException;
using System.Runtime.CompilerServices;

namespace ProjectName.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        private readonly ResponseML responseML;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
            responseML = new ResponseML();
        }

        [HttpPost]
        public ResponseML AddUser(UserML model)
        {
            try
            {
                var result = userBL.AddUser(model);

                if (result != null)
                {
                    this.responseML.Success = true;
                    this.responseML.Message = "User Added Successfully.";
                    this.responseML.Data = result;
                }
                else {
                    this.responseML.Success = false;
                    this.responseML.Message = "User Cannot be Added.";
                    this.responseML.Data = result;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error Occurred while Adding Users");
            }

            return responseML;
        }

        [HttpPost("{name}")]
        public IActionResult EditUser(string name, UserML model)
        {
            try
            {
                var result = userBL.UpdateUser(name, model);

                if (result != null)
                {
                    this.responseML.Success = true;
                    this.responseML.Message = "User Updated Successfully.";
                    this.responseML.Data = result;

                    return StatusCode(200, responseML);
                }
            }
            catch(UserException ex)
            {
                this.responseML.Success = false;
                this.responseML.Message = ex.Message;
                //this.responseML.Data = result;
                 return StatusCode(404, responseML);
            }
            return StatusCode(200,this.responseML);
        }

        [HttpGet]
        public ResponseML GetAllUser()
        {
            var result = userBL.GetAllUsers();

            if (result != null)
            {
                this.responseML.Success = true;
                this.responseML.Message = "Getting all users.";
                this.responseML.Data = result;
            }
            else
            {
                this.responseML.Success = false;
                this.responseML.Message = "No users!!!";
                this.responseML.Data = result;
            }

            return responseML;
        }

        [HttpGet("{name}")]
        public ResponseML GetUserByName(string name) 
        {
            var result = userBL.GetUserByName(name);

            if (result != null)
            {
                this.responseML.Success = true;
                this.responseML.Message = "Get user by Name.";
                this.responseML.Data = result;
            }
            else
            {
                this.responseML.Success = false;
                this.responseML.Message = "No such user found.";
                this.responseML.Data = result;
            }
            return responseML;
        }

        [HttpDelete("{id}")]
        public ResponseML DeleteUser(int id)
        {
            var result = userBL.DeleteUser(id);

            if (result != null)
            {
                this.responseML.Success = true;
                this.responseML.Message = "User Deleted Successfully.";
                this.responseML.Data = result;
            }
            else
            {
                this.responseML.Success = false;
                this.responseML.Message = "No user found";
                this.responseML.Data = result;
            }

            return responseML;
        }
    }
}
