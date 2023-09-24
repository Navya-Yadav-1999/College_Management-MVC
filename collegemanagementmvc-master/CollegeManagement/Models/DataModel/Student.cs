using System.ComponentModel.DataAnnotations;
using System;

namespace CollegeManagement.Models.DataModel
{
    public class Student
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        public string? Address1 { get; set; }

        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        public int UserId { get; set; }
    }
}
