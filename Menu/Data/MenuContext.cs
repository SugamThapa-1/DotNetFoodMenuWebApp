using Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu.Models.DishIngredient>()
                .HasKey(di => new { di.DishId, di.IngredientId });
            modelBuilder.Entity<Menu.Models.DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.DishId);
            modelBuilder.Entity<Menu.Models.DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(di => di.IngredientId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id=1, Name = "Margheritta", Price = 7.50, ImageUrl = "https://kitchenswagger.com/wp-content/uploads/2023/05/margherita-pizza-final.jpg" }
                );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Tomato Sauce" },
                new Ingredient { Id = 2, Name = "Mozzarella" }
                );

            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient {DishId = 1, IngredientId = 1 },
                new DishIngredient {DishId = 1, IngredientId = 2 }
                );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
