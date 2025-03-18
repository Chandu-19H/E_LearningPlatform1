using E_LearningPlatform.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LearningPlatform.Repository
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCoursesAsync();
        Task<Course> CreateCourseAsync(Course course);
        Task<List<Course>> GetCoursesByInstructorAsync(int instructorID);
        Task<Course> GetCourseByIdAsync(int courseId);
        Task UpdateCourseAsync(int courseId, Course course);
        Task DeleteCourseAsync(int courseId);
    }
}