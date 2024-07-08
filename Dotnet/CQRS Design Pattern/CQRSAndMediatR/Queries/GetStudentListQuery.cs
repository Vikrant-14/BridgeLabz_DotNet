using CQRSAndMediatR.Models;
using MediatR;

namespace CQRSAndMediatR.Queries
{
    public class GetStudentListQuery : IRequest<List<StudentDetails>>
    {
    }
}
