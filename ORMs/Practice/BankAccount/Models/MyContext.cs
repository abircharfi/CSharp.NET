#pragma warning restore CS8618
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Models;
public class MyContext : DbContext
{

    public MyContext(DbContextOptions options) : base (options){ }
 
    public DbSet<User> Users {get; set;}
    public DbSet<Transaction> Transactions {get; set;}
}

