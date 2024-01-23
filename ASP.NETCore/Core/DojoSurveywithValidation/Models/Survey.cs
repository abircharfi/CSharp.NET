#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace DojoSurveywithValidation.Models;

public class Survey
{
    [Required(ErrorMessage = "Name here is Required")]
    [MinLength(2,ErrorMessage = "Name must be at least 2 characters ! ")]
    public string yourName { get; set; }
    
    [Required(ErrorMessage = "Location here is Required")]
    public string dojoLocation { get; set; }

    [Required(ErrorMessage = "Favorite Language here is Required")]
    public string favoriteLanguage { get; set; }

    [CommentValidation]
    public string? comments { get; set; }
}
