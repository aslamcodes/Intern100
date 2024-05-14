﻿// <auto-generated />
using DoctorClinic.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorClinic.Migrations
{
    [DbContext(typeof(DoctorClinicContext))]
    [Migration("20240514141809_doctor-exp")]
    partial class doctorexp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoctorClinic.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialisation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Experience = 0,
                            Name = "Dr. John Doe",
                            Specialisation = "General Physician"
                        },
                        new
                        {
                            Id = 2,
                            Experience = 0,
                            Name = "Dr. Jane Doe",
                            Specialisation = "Dermatologist"
                        },
                        new
                        {
                            Id = 3,
                            Experience = 0,
                            Name = "Dr. Richard Roe",
                            Specialisation = "Cardiologist"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
