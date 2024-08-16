using CQRSPattern.Models;
using CQRSPattern.Queries.StudentQueries;
using CQRSPattern.Repositories;

namespace CQRSPattern.Handlers.StudentHandler
{
    public class GetStudentListHandler
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentListHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentDetails>> Handle(GetStudentListQuery query)
        {
            return await _studentRepository.GetStudentListAsync();
        }
    }
}
