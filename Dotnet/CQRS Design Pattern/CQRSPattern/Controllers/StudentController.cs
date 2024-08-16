using CQRSPattern.BusinessLayer.Interface;
using CQRSPattern.Commands.StudentCommand;
using CQRSPattern.DTOs;
using CQRSPattern.Handlers.StudentHandler;
using CQRSPattern.Models;
using CQRSPattern.Queries.StudentQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CreateStudentHandler _createStudentHandler;
        private readonly UpdateStudentHandler _updateStudentHandler;
        private readonly DeleteStudentHandler _deleteStudentHandler;
        private readonly GetStudentByIdHandler _getStudentByIdHandler;
        private readonly GetStudentListHandler _getStudentListHandler;
        private readonly ResponseDTO _response;
        private readonly IStudentBL _studentBL;

        public StudentController(IStudentBL studentBL)
        {
            _studentBL = studentBL;
            _response = new ResponseDTO();
        }


        [HttpGet("getAllStudents")]
        public async Task<ResponseDTO> GetStudentListAsync()
        {
            try
            {
               // var studentDetails = await _getStudentListHandler.Handle(new GetStudentListQuery());
                var studentDetails = await _studentBL.GetStudentListAsync();

                _response.Success = true;
                _response.Message = "List fetched Successfully";
                _response.Data = studentDetails;

                return _response;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                _response.Success = false;
                _response.Message = ex.Message;

                return _response;
            }
        }

        [HttpPost("addStudent")]
        public async Task<ResponseDTO> AddStudentAsync(StudentDTO model)
        {
            try
            {
                //var studentDetails = await _createStudentHandler.Handle(new CreateStudentCommand(model));
                var studentDetails = await _studentBL.AddStudentAsync(model);

                _response.Success = true;
                _response.Message = "Student added Successfully";
                _response.Data = studentDetails;

                return _response;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                _response.Success = false;
                _response.Message = ex.Message;

                return _response;
            }
        }
    }

}
