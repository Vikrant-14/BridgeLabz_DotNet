using CQRSPattern.BusinessLayer.Interface;
using CQRSPattern.Commands.StudentCommand;
using CQRSPattern.Controllers;
using CQRSPattern.DTOs;
using CQRSPattern.Handlers.StudentHandler;
using CQRSPattern.Models;
using CQRSPattern.Queries.StudentQueries;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CQRSPattern.BusinessLayer.Service
{
    public class StudentBL : IStudentBL
    {
        private readonly CreateStudentHandler _createStudentHandler;
        private readonly UpdateStudentHandler _updateStudentHandler;
        private readonly DeleteStudentHandler _deleteStudentHandler;
        private readonly GetStudentByIdHandler _getStudentByIdHandler;
        private readonly GetStudentListHandler _getStudentListHandler;


        public StudentBL(CreateStudentHandler createStudentHandler,
                                 UpdateStudentHandler updateStudentHandler,
                                 DeleteStudentHandler deleteStudentHandler,
                                 GetStudentByIdHandler getStudentByIdHandler,
                                 GetStudentListHandler getStudentListHandler)
        {
            _createStudentHandler = createStudentHandler;
            _updateStudentHandler = updateStudentHandler;
            _deleteStudentHandler = deleteStudentHandler;
            _getStudentByIdHandler = getStudentByIdHandler;
            _getStudentListHandler = getStudentListHandler;
        }

        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            try
            {
                var studentDetails = await _getStudentListHandler.Handle(new GetStudentListQuery());

                return studentDetails;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("addStudent")]
        public async Task<StudentDetails> AddStudentAsync(StudentDTO model)
        {
            try
            {
                var studentDetails = await _createStudentHandler.Handle(new CreateStudentCommand(model));

                return studentDetails;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
