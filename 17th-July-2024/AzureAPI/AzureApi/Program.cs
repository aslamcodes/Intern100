using AzureApi.Contexts;
using AzureApi.Interfaces;
using AzureApi.Models;
using AzureApi.Repositories;
using AzureApi.Services;
using Microsoft.EntityFrameworkCore;

namespace AzureApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            #region Contexts
            builder.Services.AddDbContext<ProductsContext>(options => options.UseSqlServer(@"Server=C0RBBX3\SQLSERVERG3;Integrated Security=true;Initial Catalog=test1;TrustServerCertificate=True"));
            #endregion

            #region Services
            builder.Services.AddScoped<IProductService, ProductService>();
            #endregion

            #region Repositories
            builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>();
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
