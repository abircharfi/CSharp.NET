#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using DateValidator.Attributes; 
namespace DateValidator.Models;

    public class User
    {
        [FutureDate(ErrorMessage = "Please enter a date in the future.")]
        public DateTime DateInFuture { get; set; }
    }
