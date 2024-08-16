using CQRSPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSPattern.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<StudentDetails> Students { get; set; }
        
    }
}
