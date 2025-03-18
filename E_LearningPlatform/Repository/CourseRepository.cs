using E_LearningPlatform.Data;
using E_LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningPlatform.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ELearningDbContext _context;

        public CourseRepository(ELearningDbContext context)
        {
            _context = context;
        }
        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await _context.Courses.FindAsync(courseId);
        }

        public async Task<List<Course>> GetCoursesByInstructorAsync(int instructorID)
        {
            return await _context.Courses.Where(c => c.InstructorId == instructorID).ToListAsync();
        }

        public async Task UpdateCourseAsync(int courseId, Course course)
        {
            var updatedcourse = await _context.Courses.FindAsync(courseId);

            updatedcourse.Title = course.Title;
            updatedcourse.Description = course.Description;
            updatedcourse.ContentURL = course.ContentURL;

            _context.Courses.Update(updatedcourse);
            await _context.SaveChangesAsync();
        }
    }
}