using CQRSAndMediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatR.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options):base(options) { }
        
        public DbSet<StudentDetails> Students { get; set; }
    }
}