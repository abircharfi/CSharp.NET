#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.ComponentModel;
using WeddingPlanner.Attributes; 

namespace WeddingPlanner.Models;

public class Wedding
    {
        [Key]
        public int WeddingId {get;set;}

        [Required]
        [Display(Name = "Wedder One")]
        public string WedderOne {get;set;}

        [Required]
        [Display(Name = "Wedder Two")]
        public string WedderTwo {get;set;}

        [Required]
        [FutureDateAttribute]
        [Display(Name = "Date")]
        public DateTime WeddDate {get;set;}

        [Required]
        [Display(Name = "Wedding Address")]
        public string WeddAddress {get;set;}
        //The UserId of who created the Wedding
        public int UserId {get;set;} 
        // Navigation property for the user who created the wedding
        public User? Creator { get; set; }
        //The list of Users who are attending this Wedding
        public List<Attendance> Guests { get; set; } = new List<Attendance>();
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }