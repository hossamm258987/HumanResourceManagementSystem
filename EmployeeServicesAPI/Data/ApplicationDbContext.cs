using EmployeeServicesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeServicesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<JobTittle> JobTittles { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
    }
}
