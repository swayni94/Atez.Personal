
using Atez.Personal.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Atez.Personal.Data
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Title> Titles { get; set; }
        

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options)
        {
        }
    }
}
