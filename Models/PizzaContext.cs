using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_post_ef.Models
{
    public class PizzaContext : DbContext
    {
        public DbSet<PizzaModel> Pizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DbPizza;Integrated Security=True;Pooling=False");
        }
    }
}

