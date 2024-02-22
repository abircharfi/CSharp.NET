using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Attributes ;

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
    
         if (((DateTime)value) <= DateTime.Now)
            {
                return new ValidationResult("Only dates in the future are allowed!");
            }
            return ValidationResult.Success;
    
    }
}
