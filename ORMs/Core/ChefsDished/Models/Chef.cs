#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using ChefsDished.Attributes; 

namespace ChefsDished.Models ;

public class Chef 
{
    [Key]
    public int ChefId{get; set;}
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Date of birth is required.")]
    [DateOfBirthValidation]
    public DateTime DateOfBirth{get; set;}

    public List<Dish> CreatedDishes {get;set;} = new List<Dish>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}