using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.Models.ViewModel
{
    public class TeacherViewModel
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "FirstName cannot be exceed 20 characters")]
        [Display(Name = "Enter First Name")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Enter Last Name")]
        public string? LastName { get; set; }
        [Required]
        [RegularExpression(@"^[a-z0-9](\.?[a-z0-9]){5,}@miraclesoft\.com$",
    ErrorMessage = "Please enter correct email address")]
        public string? EmailId { get; set; }

        [Required]
        [Display(Name = "Enter Permanent Address")]
        public string? Address1 { get; set; }
        [Required]
        [Display(Name = "Enter Present Address")]
        public string? Address2 { get; set; }
        [Required]
        [Display(Name = "Enter City")]
        public string? City { get; set; }
        [Required]
        [Display(Name = "Enter State")]
        public string? State { get; set; }

        public int UserId { get; set; }
    }
}
