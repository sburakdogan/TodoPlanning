using Microsoft.EntityFrameworkCore;
using TodoPlanning.Data.Entities;

namespace TodoPlanning.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Developer> Developers { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

    }
}
