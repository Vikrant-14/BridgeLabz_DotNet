using CQRSAndMediatR.Data;
using CQRSAndMediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatR.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<StudentDetails> AddStudentAsync(StudentDetails student)
        {
            var result = _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<int> DeleteStudentAsync(int Id)
        {
            var result = _context.Students.Where(x => x.Id == Id).FirstOrDefault();
            _context.Students.Remove(result);

            return await _context.SaveChangesAsync();
        }

        public async Task<StudentDetails> GetStudentByIdAsync(int Id)
        {
            return await _context.Students.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<int> UpdateStudentAsync(StudentDetails student)
        {
            _context.Students.Update(student);
            return await _context.SaveChangesAsync();
        }
    }
}
