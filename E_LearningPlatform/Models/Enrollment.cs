using System.ComponentModel.DataAnnotations;

namespace E_LearningPlatform.Models
{
    public class Enrollment
    {
        [Key]

        public int EnrollmentId { get; set; }
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }
        [Required]
        public double Progress { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Course? Course { get; set; }
    }
}