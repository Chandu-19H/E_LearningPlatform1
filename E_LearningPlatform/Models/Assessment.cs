using System.ComponentModel.DataAnnotations;

namespace E_LearningPlatform.Models
{
    public class Assessment
    {
        [Key]
        public int AssessmentId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Maxscore { get; set; }
        public Course? Course { get; set; }
        public ICollection<Submission> ?Submissions { get; set; }
    }
}
