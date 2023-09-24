using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.Models
{
    public class Audit
    {
        public Audit()
        {
            CreateDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
