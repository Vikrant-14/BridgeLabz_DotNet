using CQRSPattern.Commands.StudentCommand;
using CQRSPattern.DTOs;
using CQRSPattern.Models;
using CQRSPattern.Repositories;

namespace CQRSPattern.Handlers.StudentHandler
{
    public class CreateStudentHandler
    {
        public IStudentRepository _studentRepository { get; }
        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDetails> Handle(CreateStudentCommand command)
        {
            var studentDetails = new StudentDetails()
            {
                StudentName = command.StudentName,
                StudentEmail = command.StudentEmail,
                StudentAddress = command.StudentAddress,
                StudentAge = command.StudentAge
            };

            return await _studentRepository.AddStudentAsync(studentDetails);
        }

    }
}
