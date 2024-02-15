#pragma warning disable CS8618 
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;



namespace BankAccount.Models;
public class User
{
    [Key]
    public int UserId{get; set;}
    [Required(ErrorMessage ="First Name is required")]
    [MinLength(2, ErrorMessage ="First name should be at least 2 characters !")]
    public string FirstName{get; set;}
    [Required(ErrorMessage="Last name is required")]
    [MinLength(2, ErrorMessage ="Last name should be at least 2 characters ")]
    public string LastName {get; set;}
    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email {get; set;}
    [Required(ErrorMessage="Password is required")]
    [MinLength(8, ErrorMessage ="Password should be at least 8 characters")]
    [DataType(DataType.Password)]
    public string Password {get; set;}
    [Required(ErrorMessage="Password Confirm is required")]
    [NotMapped]
    [DisplayName("Confirm Password" )]
    [Compare("Password", ErrorMessage="The password and confirmation password do not match")]
    [DataType(DataType.Password)]
    public string ConfirmPassword {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Transaction> Transactions {get; set;} = new List<Transaction>();
}