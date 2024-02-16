#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsandCategories.Models;
public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required(ErrorMessage="The Name is required !")]
    public string Name { get; set; } 
    [Required(ErrorMessage="The description is required !")]
    public string Description { get; set; }
    [Required(ErrorMessage="The Price is required !")]
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Association> ProductAssociated { get; set; } = new List<Association>();
}