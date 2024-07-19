using AzureApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureApi.Contexts
{
    public class ProductsContext(DbContextOptions<ProductsContext> options) : DbContext(options)

    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).UseIdentityColumn();

            modelBuilder.Entity<Product>().HasData([
                new Product() { Id = 1,  Name = "Test", Picture = "Test", Price = 123 },
                new Product() { Id = 2, Name = "test2", Picture = "Test2.url", Price = 456 }
                ]);
        }

    }
}
