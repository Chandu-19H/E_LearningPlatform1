using System.ComponentModel.DataAnnotations;

namespace E_LearningPlatform.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }

        public ICollection<Instructor>? Instructors { get; set; }
        public ICollection<Student>? Students { get; set; }

    }
}
