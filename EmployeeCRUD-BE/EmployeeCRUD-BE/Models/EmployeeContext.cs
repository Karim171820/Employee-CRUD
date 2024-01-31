using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD_BE.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options) :base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
