using CQRSAndMediatR.Commands;
using CQRSAndMediatR.Repositories;
using MediatR;

namespace CQRSAndMediatR.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
        {
            var studentDetail = await _studentRepository.GetStudentByIdAsync(command.Id);

            if (studentDetail == null) { return default; }

            return await _studentRepository.DeleteStudentAsync(studentDetail.Id);
        }
    }
}
