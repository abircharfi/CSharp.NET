#pragma warning disable CS8618
namespace WeddingPlanner.Models;
using System.ComponentModel.DataAnnotations;
public class UserLogin
{
    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string LoginEmail {get; set;}
    
    [Required(ErrorMessage="Password is required")]
    [DataType(DataType.Password)]
    public string LoginPassword {get; set;}

}