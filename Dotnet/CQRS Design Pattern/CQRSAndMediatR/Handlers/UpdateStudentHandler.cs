using CQRSAndMediatR.Commands;
using CQRSAndMediatR.Models;
using CQRSAndMediatR.Repositories;
using MediatR;

namespace CQRSAndMediatR.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            var studentDetail = await _studentRepository.GetStudentByIdAsync(command.Id);

            if (studentDetail == null) { return default; }
            
            studentDetail.StudentName = command.StudentName;
            studentDetail.StudentEmail = command.StudentEmail;
            studentDetail.StudentAge = command.StudentAge;
            studentDetail.StudentAddress = command.StudentAddress;

            return await _studentRepository.UpdateStudentAsync(studentDetail);
        }
    }
}
