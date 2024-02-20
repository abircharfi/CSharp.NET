using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Attributes ;

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
    
        if (value is DateTime date)
        {
            if (date > DateTime.Now)
            {
        return ValidationResult.Success;
            }
        }
        return new ValidationResult("Date must be in the future");
    
    }
}
