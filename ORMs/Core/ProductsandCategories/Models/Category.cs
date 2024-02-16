#pragma warning disable CS8618
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ProductsandCategories.Models;
public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Required(ErrorMessage="The Name is required !")]
    public string Name { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Association> CategoryAssociated { get; set; } = new List<Association>();
}