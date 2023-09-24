using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.Models.DataModel
{
    public class Teacher
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]

        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
      
        [Required]
        public string? Address1 { get; set; }
        [Required]
        public string? Address2 { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public string? State { get; set; }
        public int UserId { get; set; }
    }
}
