using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EmployeeSection.DomainLayer.Entities;

namespace EmployeeSection.DataAccessLayer
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.FullName).IsUnique();
        }
    }
}
