using CQRSPattern.Commands.StudentCommand;
using CQRSPattern.Repositories;

namespace CQRSPattern.Handlers.StudentHandler
{
    public class UpdateStudentHandler
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(UpdateStudentCommand command)
        {
            var studentDetails = await _studentRepository.GetStudentByIdAsync(command.Id);
            if (studentDetails == null)
            {
                return default;
            }

            return await _studentRepository.UpdateStudentAsync(studentDetails);
        }
    }
}
