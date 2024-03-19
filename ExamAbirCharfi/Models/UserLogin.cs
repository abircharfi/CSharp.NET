#pragma warning disable CS8618
namespace ExamAbirCharfi.Models;
using System.ComponentModel.DataAnnotations;
public class UserLogin
{
    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [Display(Name = "Email")]
    public string LoginEmail {get; set;}
    
    [Required(ErrorMessage="Password is required")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string LoginPassword {get; set;}

}