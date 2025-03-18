using System.ComponentModel.DataAnnotations;

namespace E_LearningPlatform.Models
{
    public class Submission
    {
        [Key]
        public int SubmissionId { get; set; }
        public int AssessmentId { get; set; }
        public int StudentId { get; set; }
        public int Score { get; set; }
        public virtual Assessment? Assessment { get; set; }
        public virtual Student ?Student { get; set; }
    }
}
