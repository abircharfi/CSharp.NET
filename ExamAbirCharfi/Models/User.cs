
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.ComponentModel;


namespace ExamAbirCharfi.Models;
public class User
{
    [Key]
    public int UserId {get; set;}

    [Required(ErrorMessage="First name is required")]
    [MinLength(2, ErrorMessage ="First name should be at least 2 characters ")]
    [DisplayName("First Name" )]
    public string Name {get; set;}

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

    // Navigation property for posts created by the user
    public List<Post> PostCreated { get; set; } = new List<Post>();

    //The list of Post that a User have liked

    public List<Like> MyLikes  {get;set;}  = new List<Like>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
}