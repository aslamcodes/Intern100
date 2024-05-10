
using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLib.Models;

namespace RequestTrackerModelLib.Context
{
    public class RequestTrackerContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=C0RBBX3\SQLSERVERG3;Integrated Security=true;Initial Catalog=dbEmployeeTrackerCF;TrustServerCertificate=true");
        }
    }
}
