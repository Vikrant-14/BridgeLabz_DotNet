using CQRSAndMediatR.Models;
using MediatR;

namespace CQRSAndMediatR.Queries
{
    public record GetStudentListQuery : IRequest<List<StudentDetails>>;
    //public class GetStudentListQuery : IRequest<List<StudentDetails>>
    //{
    //}
}
