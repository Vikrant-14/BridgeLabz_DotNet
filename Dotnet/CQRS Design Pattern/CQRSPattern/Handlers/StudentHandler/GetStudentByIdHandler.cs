using CQRSPattern.Models;
using CQRSPattern.Queries.StudentQueries;
using CQRSPattern.Repositories;

namespace CQRSPattern.Handlers.StudentHandler
{
    public class GetStudentByIdHandler
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDetails> Handle(GetStudentByIdQuery query)
        {
            return await _studentRepository.GetStudentByIdAsync(query.Id);
        }
    }
}
