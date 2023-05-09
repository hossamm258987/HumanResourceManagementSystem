using Microsoft.EntityFrameworkCore;
using PayRollServicesAPI.Models;

namespace PayRollServicesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Deduction> Deductions { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
