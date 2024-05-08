using System;
using System.Collections.Generic;
using DoctorClinicDALLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicDALLibrary.Context;

public partial class DoctorclinicContext : DbContext
{
    public DoctorclinicContext()
    {
    }

    public DoctorclinicContext(DbContextOptions<DoctorclinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=C0RBBX3\\SQLSERVERG3;Database=doctorclinic;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3213E83FD5FBE82D");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Doctorid).HasColumnName("doctorid");
            entity.Property(e => e.Patientid).HasColumnName("patientid");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Doctorid)
                .HasConstraintName("fk_doctor");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Patientid)
                .HasConstraintName("fk_patient");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doctors__3213E83F7F664187");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Qualification)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("qualification");
            entity.Property(e => e.Speciality)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("speciality");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patients__3213E83F2FB49B4E");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Bloodgroup)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("bloodgroup");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Sex)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sex");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
