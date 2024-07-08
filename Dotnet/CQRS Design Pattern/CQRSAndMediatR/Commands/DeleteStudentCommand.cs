using MediatR;

namespace CQRSAndMediatR.Commands
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
