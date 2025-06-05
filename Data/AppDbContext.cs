using Microsoft.EntityFrameworkCore;
using Task.Models.Entity;

namespace Task.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base( options) { }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
              .HasMany(e => e.Employees)
              .WithOne(d => d.Department)
              .HasForeignKey(e => e.DepartmentId);

        }

    }
}
