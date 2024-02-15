#pragma warning disable 
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BankAccount.Models;

public class Transaction
{ 
    [Key]
    public int TransactionId {get; set;}
    public decimal Amount {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;}= DateTime.Now;
    public User? Tasker {get; set;}

}