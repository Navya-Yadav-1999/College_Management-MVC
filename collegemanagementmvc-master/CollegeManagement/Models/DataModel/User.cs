using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.Models.DataModel
{
    public class User:Audit
    {

        [Required(ErrorMessage = "Please enter correct email address")]
        public string? EmailId { get; set; }

        [Required]
        [Display(Name = "Please enter password")]
        public string? UserPassword { get; set; }
        public string? UserType { get; set; }
    }
}
