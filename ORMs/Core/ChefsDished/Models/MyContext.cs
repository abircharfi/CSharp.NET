#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace ChefsDished.Models;

public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<Chef> Chefs { get; set; }
    public DbSet<Dish> Dishes { get; set; }  
}