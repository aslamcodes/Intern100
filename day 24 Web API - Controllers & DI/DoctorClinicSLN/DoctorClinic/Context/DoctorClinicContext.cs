using DoctorClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinic.Context
{
    public class DoctorClinicContext : DbContext
    {
        public DoctorClinicContext(DbContextOptions<DoctorClinicContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                               new Doctor
                               {
                                   Id = 1,
                                   Name = "Dr. John Doe",
                                   Specialisation = "General Physician",

                               },
                               new Doctor
                               {
                                   Id = 2,
                                   Name = "Dr. Jane Doe",
                                   Specialisation = "Dermatologist",

                               },
                               new Doctor
                               {
                                   Id = 3,
                                   Name = "Dr. Richard Roe",
                                   Specialisation = "Cardiologist",

                               }
            );


        }
    }
}
