
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.ComponentModel;
namespace ExamAbirCharfi.Models;
public class Post
{
    [Key]
    public int PostId {get; set;}

    [Required(ErrorMessage="Image is required")]
    [DisplayName("Image (URL format please)")]
    public string Image {get; set;}


    [Required(ErrorMessage = "Title is required")]
    public string Title {get; set;}

    [Required(ErrorMessage = "Medium is required")]
    public string Medium {get; set;}

    [Display(Name = "For Sale ?")]
    public bool IsForSale {get; set;}

    // Navigation property
    public int UserId {get;set;} 
    public User? Creator { get; set; }
    // users who like the post
    public List<Like> Likers  {get;set;}  = new List<Like>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
}