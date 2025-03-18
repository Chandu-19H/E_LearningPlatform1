namespace E_LearningPlatform.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
