
using System.ComponentModel.DataAnnotations;

public class CommentValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        
        if (value == null)
        {
            return ValidationResult.Success; 
        }

        
        if (value.ToString().Length <= 20)
        {
            return new ValidationResult("Comment should be more than 20 characters if included.");
        }

        return ValidationResult.Success; 
    }
}
