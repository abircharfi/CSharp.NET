using System;
using System.ComponentModel.DataAnnotations;

namespace DateValidator.Attributes ;

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // You first may want to unbox "value" here and cast to to a DateTime variable!

         
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
