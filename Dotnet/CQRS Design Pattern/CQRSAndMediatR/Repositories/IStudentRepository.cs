using CQRSAndMediatR.Models;

namespace CQRSAndMediatR.Repositories
{
    public interface IStudentRepository
    {
        public Task<StudentDetails> AddStudentAsync(StudentDetails student);
        public Task<int> DeleteStudentAsync(int Id);
        public Task<StudentDetails> GetStudentByIdAsync(int Id);
        public Task<List<StudentDetails>> GetStudentListAsync();
        public Task<int> UpdateStudentAsync(StudentDetails student);
    }
}