using CQRSPattern.Commands.StudentCommand;
using CQRSPattern.Models;
using CQRSPattern.Repositories;

namespace CQRSPattern.Handlers.StudentHandler
{
    public class DeleteStudentHandler
    {
        public IStudentRepository _studentRepository { get; set;}
        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(DeleteStudentCommand command)
        {
            var studentDetail = await _studentRepository.GetStudentByIdAsync(command.Id);
            
            if (studentDetail == null)
            {
                return default;
            }

            return await _studentRepository.DeleteStudentAsync(studentDetail.Id);
        }

    }
}
