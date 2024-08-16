using CQRSPattern.DTOs;
using CQRSPattern.Models;

namespace CQRSPattern.BusinessLayer.Interface
{
    public interface IStudentBL
    {
        Task<StudentDetails> AddStudentAsync(StudentDTO model);
        Task<List<StudentDetails>> GetStudentListAsync();
    }
}