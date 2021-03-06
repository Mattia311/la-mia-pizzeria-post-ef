using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace la_mia_pizzeria_post_ef.Models
{
    public class NuovaPizzaContext : DbContext
    {
        public DbSet<NuovaPizza> Pizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DbPizza;Integrated Security=True;Pooling=False");
        }
    }
}
