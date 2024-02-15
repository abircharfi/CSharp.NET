#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BankAccount.Models;

public class LoginUser
{
    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string LoginEmail {get; set;}
    
    [Required(ErrorMessage="Password is required")]
    [DataType(DataType.Password)]
    public string LoginPassword {get; set;}

}