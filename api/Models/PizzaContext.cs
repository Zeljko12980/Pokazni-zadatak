using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class PizzaContext:DbContext
    {
     public PizzaContext(DbContextOptions<PizzaContext> options):base(options)
     {
        
     }

     public DbSet<Pizza> Pizzas{get;set;}
     public DbSet<Order> Orders{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}