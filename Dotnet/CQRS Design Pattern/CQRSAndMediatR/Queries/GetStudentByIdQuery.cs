using CQRSAndMediatR.Models;
using MediatR;

namespace CQRSAndMediatR.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentDetails>
    {
        public int Id { get; set; }
    }
}
