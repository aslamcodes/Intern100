
using Microsoft.EntityFrameworkCore;
using Pizza.NET.Contexts;
using Pizza.NET.Repositories;
using Pizza.NET.Services;
using Pizza.NET.Services.Interfaces;

namespace Pizza.NET
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

            #region Context
            builder.Services.AddDbContext<PizzaChainContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
            });
            #endregion

            #region Services
            builder.Services.AddScoped<IPizzaService, PizzaService>();
            builder.Services.AddScoped<IUserAuthService, UserAuthService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            #endregion

            #region Repositories
            builder.Services.AddScoped<IRepository<int, Models.Pizza>, PizzaRepository>();
            builder.Services.AddScoped<IRepository<int, Models.User>, UserRepository>();
            builder.Services.AddScoped<IRepository<int, Models.Order>, OrderRepository>();
            builder.Services.AddScoped<IRepository<int, Models.PizzaStock>, PizzaStockRepository>();

            #endregion

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
