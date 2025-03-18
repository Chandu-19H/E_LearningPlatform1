using E_LearningPlatform.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LearningPlatform.Services
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCoursesAsync();
        Task CreateCourseAsync(Course course);
        Task<Course> GetCourseByIdAsync(int courseId);
        Task<List<Course>> GetCoursesByInstructorAsync(int instructorId);
        Task UpdateCourseAsync(int courseId, Course course);
        Task DeleteCourseAsync(int courseId);
    }
}