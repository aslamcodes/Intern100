using Microsoft.EntityFrameworkCore;

namespace Pizza.NET.Contexts
{
    public class PizzaChainContext : DbContext
    {


        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.Pizza> Pizzas { get; set; }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.PizzaStock> PizzaStocks { get; set; }

        public PizzaChainContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Relations
            modelBuilder.Entity<Models.Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Models.Order>()
                .HasOne(o => o.Pizza)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.PizzaId);

            modelBuilder.Entity<Models.PizzaStock>()
                .HasOne(ps => ps.Pizza)
                .WithOne(p => p.Stock)
                .HasForeignKey<Models.PizzaStock>(ps => ps.PizzaId);
            #endregion

            #region Indexes
            modelBuilder.Entity<Models.User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Models.PizzaStock>()
                .HasIndex(ps => ps.PizzaId)
                .IsUnique(true);
            #endregion

            #region Seed
            modelBuilder.Entity<Models.Pizza>().HasData(
                               new Models.Pizza { Id = 1, Name = "Margherita", Description = "Tomato sauce, mozzarella cheese, basil", Price = 5.99m, ImageUrl = "https://cdn.pixabay.com/photo/2017/12/09/08/18/pizza-3007395_960_720.jpg" },
                               new Models.Pizza { Id = 2, Name = "Pepperoni", Description = "Tomato sauce, mozzarella cheese, pepperoni", Price = 6.99m, ImageUrl = "https://cdn.pixabay.com/photo/2017/12/09/08/18/pizza-3007395_960_720.jpg" },
                               new Models.Pizza { Id = 3, Name = "Hawaiian", Description = "Tomato sauce, mozzarella cheese, ham, pineapple", Price = 7.99m, ImageUrl = "https://cdn.pixabay.com/photo/2017/12/09/08/18/pizza-3007395_960_720.jpg" }
                 );

            modelBuilder.Entity<Models.PizzaStock>().HasData(
                new Models.PizzaStock { Id = 1, PizzaId = 1, Stock = 10 },
                new Models.PizzaStock { Id = 2, PizzaId = 2, Stock = 10 },
                new Models.PizzaStock { Id = 3, PizzaId = 3, Stock = 10 }
                );

            #endregion
        }

    }
}
