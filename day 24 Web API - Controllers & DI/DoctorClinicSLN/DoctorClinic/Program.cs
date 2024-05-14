using DoctorClinic.Context;
using DoctorClinic.Models;
using DoctorClinic.Repository;
using DoctorClinic.Services;
using DoctorClinic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Console = Colorful.Console;

namespace DoctorClinic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteAscii("DoctorClinic", Color.Purple);

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DoctorClinicContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

            builder.Services.AddScoped<IDoctorService, DoctorService>();

            builder.Services.AddScoped<IRepository<int, Doctor>, DoctorRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
