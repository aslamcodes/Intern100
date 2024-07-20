using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
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
        public static async void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            #region Contexts
            const string secretName = "DefaultConnection";
            var keyVaultName = "aslam-keys";
            var kvUri = $"https://{keyVaultName}.vault.azure.net";
            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            var secret = await client.GetSecretAsync(secretName);
            var connectionString = secret.Value.Value;

            builder.Services.AddDbContext<ProductsContext>(options => options.UseSqlServer(connectionString));
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
