using System.ComponentModel.DataAnnotations;
using ExamAbirCharfi.Models;

public class Like
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }

    //Navigation properties
    public User? User { get; set; }
    public Post? Post { get; set; }
}