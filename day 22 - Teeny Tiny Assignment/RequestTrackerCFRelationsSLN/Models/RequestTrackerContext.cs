using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class RequestTrackerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=C0RBBX3\SQLSERVERG3;Integrated Security=true;Initial Catalog=dbEmployeeTrackerCF;TrustServerCertificate=true");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestSolution> RequestSolutions { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 101, Name = "Ramu", Password = "ramu123", Role = "Admin" },
                new Employee { Id = 102, Name = "Somu", Password = "somu123", Role = "Admin" },
                new Employee { Id = 103, Name = "Bimu", Password = "bimu123", Role = "User" }
                );

            modelBuilder.Entity<Request>().HasKey(r => r.RequestNumber);

            modelBuilder.Entity<Request>()
               .HasOne(r => r.RaisedByEmployee)
               .WithMany(e => e.RequestsRaised)
               .HasForeignKey(r => r.RequestRaisedBy)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            modelBuilder.Entity<Request>()
               .HasOne(r => r.RequestClosedByEmployee)
               .WithMany(e => e.RequestsClosed)
               .HasForeignKey(r => r.RequestClosedBy)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);

            modelBuilder.Entity<RequestSolution>().HasKey(s => s.SolutionNumber);

            modelBuilder.Entity<RequestSolution>()
                .HasOne(s => s.ForRequest)
                .WithMany(r => r.RequestSolutions)
                .HasForeignKey(s => s.RequestNumber)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<RequestSolution>()
                .HasOne(s => s.PostedBy)
                .WithMany(e => e.RequestSolutions)
                .HasForeignKey(s => s.SolutionPostedBy)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Feedback>()
                .HasOne(feedback => feedback.Solution)
                .WithMany(Solution => Solution.FeedbacksForSolution)
                .HasForeignKey(feedback => feedback.SolutionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
