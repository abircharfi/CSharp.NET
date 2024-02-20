
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.ComponentModel;
namespace WeddingPlanner.Models;
public class User
{
    [Key]
    public int UserId {get; set;}
    [Required(ErrorMessage="First name is required")]
    [MinLength(2, ErrorMessage ="First name should be at least 2 characters ")]
    [DisplayName("First Name" )]
    public string FirstName {get; set;}
    [Required(ErrorMessage="Last name is required")]
    [MinLength(2, ErrorMessage ="Last name should be at least 2 characters ")]
    [DisplayName("Last Name" )]
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
    [DisplayName("PW Confirm " )]
    [Compare("Password", ErrorMessage="The password and confirmation password do not match")]
    [DataType(DataType.Password)]
    public string ConfirmPassword {get; set;}

    // Navigation property for weddings created by the user
    public List<Wedding> WeddingsCreated { get; set; } = new List<Wedding>();
    //The list of Weddings that a User is attending
    public List<Attendance> Attendances  {get;set;}  = new List<Attendance>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
}