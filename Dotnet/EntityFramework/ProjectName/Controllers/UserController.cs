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

        [HttpPost("adduser")]
        public IActionResult AddUser(UserML model)
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
                else
                {
                    this.responseML.Success = false;
                    this.responseML.Message = "User cannot be added.";
                    this.responseML.Data = result;

                    return StatusCode(500, responseML);
                }

            }
            catch (Exception ex)
            {
                this.responseML.Success = false;
                this.responseML.Message = ex.Message;

                return StatusCode(500, responseML);
            }

            return StatusCode(201, responseML);
        }

        [HttpPost("updateuser/{name}")]
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

        [HttpGet("getusers")]
        public IActionResult GetAllUser()
        {
            try
            {
                var result = userBL.GetAllUsers();

                if (result != null)
                {
                    this.responseML.Success = true;
                    this.responseML.Message = "Getting all users.";
                    this.responseML.Data = result;
                }
            }
            catch(UserException ex)
            {
                this.responseML.Success = false;
                this.responseML.Message = ex.Message;

                return StatusCode(404, responseML);
            }
         

            return StatusCode(200, responseML);
        }

        [HttpGet("getuserbyname/{name}")]
        public IActionResult GetUserByName(string name) 
        {
            try
            {
                var result = userBL.GetUserByName(name);

                if (result != null)
                {
                    this.responseML.Success = true;
                    this.responseML.Message = "Get user by Name.";
                    this.responseML.Data = result;
                }
            }
            catch (UserException ex)
            {
                this.responseML.Success = false;
                this.responseML.Message = ex.Message;

                return StatusCode(404, responseML);
            }

            return StatusCode(200, responseML);
        }

        [HttpDelete("deleteuser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var result = userBL.DeleteUser(id);

                if (result != null)
                {
                    this.responseML.Success = true;
                    this.responseML.Message = "User Deleted Successfully.";
                    this.responseML.Data = result;
                }
            }
            catch(UserException ex)
            {
                this.responseML.Success = false;
                this.responseML.Message = ex.Message;

                return StatusCode(404, responseML);
            }

            return StatusCode(200, responseML);
        }
    }
}
