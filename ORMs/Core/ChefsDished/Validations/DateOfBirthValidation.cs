using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsDished.Attributes ;

public class DateOfBirthValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
    
        if (value is DateTime DateOfBirth)
        {
            if (DateOfBirth < DateTime.Now)
            {
                if ((DateTime.Today.Year - DateOfBirth.Year)>= 18)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Chef must be at least 18 years old");
                }
            }
            else
            {
                 return new ValidationResult("Date must be in the Past");
            }
        }

         return new ValidationResult("Invalid date format.");
       
    
    }
}
