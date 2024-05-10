using Microsoft.EntityFrameworkCore;
using PizzaCodeFirst.Models;

namespace PizzaCodeFirst.Contexts
{
    public class PizzaShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO:Change this
            optionsBuilder.UseSqlServer("Data Source=G3SLAPTOP\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbPizzaShop;");
        }
        public DbSet<Pizza> Pizzas { get; set; }
    }
}
