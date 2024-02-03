#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required (ErrorMessage ="Dish's Name is required !")]
    public string Name { get; set; } 
    [Required (ErrorMessage ="Dish's Chef name is required !")]
    public string Chef { get; set; }
    [Range(1,5, ErrorMessage ="Tastiness must be between 1 and 5")]
    public int Tastiness { get; set; }
    [Range(1,int.MaxValue, ErrorMessage="Calories must be more than 0")]
    public int Calories { get; set; }
    [DataType(DataType.MultilineText)]
    [Required (ErrorMessage ="Description is required !")]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}