using CQRSPattern.Models;

namespace CQRSPattern.Repositories
{
    public interface IStudentRepository
    {
        Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails);
        Task<int> DeleteStudentAsync(int Id);
        Task<StudentDetails> GetStudentByIdAsync(int Id);
        Task<List<StudentDetails>> GetStudentListAsync();
        Task<int> UpdateStudentAsync(StudentDetails studentDetails);
    }
}