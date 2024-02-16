#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsandCategories.Models;
public class Association
{
    [Key]
    public int AssociationId {get; set;}
    public int CategoryId { get; set; }
    public int ProductId { get; set; }
    public Product? AssociatedProduct { get; set; }
    public Category? AssociatedCategory { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}