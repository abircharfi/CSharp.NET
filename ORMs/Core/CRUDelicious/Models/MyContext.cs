#pragma warning disable CS8618

using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

// the MyContext class representing a session with our MySQL database, allowing us to query for or save data
public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Dish> Dishes { get; set; } 
}
