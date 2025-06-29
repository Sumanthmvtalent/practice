using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAPIProjectPractice.Models;

namespace WebAPIProjectPractice.DataBaseAccess
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>options):base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
