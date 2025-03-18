using E_LearningPlatform.Models;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using E_LearningPlatform.Repository;
using System.Threading.Tasks;
using E_LearningPlatform.Services;
using E_LearningPlatform.Exceptions;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace E_LearningPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseRepository;

        public CourseController(ICourseService courseRepository)
        {
            _courseRepository = courseRepository;
        }
        [HttpGet] // Added method
        public async Task<IActionResult> GetAllCourses()
        {
            try
            {
                var courses = await _courseRepository.GetAllCoursesAsync();
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving courses: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] Course course)
        {
            try
            {
                if (course == null)
                {
                    return BadRequest("Course data is required");
                }
                await _courseRepository.CreateCourseAsync(course);
                return CreatedAtAction(nameof(GetCourseById), new { courseId = course.CourseId }, course);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating course: {ex.Message}");
            }
        }

        [HttpGet("instructor/{instructorID}")]
        public async Task<IActionResult> GetCoursesByInstructor(int instructorID)
        {
            try
            {
                var courses = await _courseRepository.GetCoursesByInstructorAsync(instructorID);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving courses: {ex.Message}");
            }
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourseById(int courseId)
        {
            try
            {
                var course = await _courseRepository.GetCourseByIdAsync(courseId);
                if (course == null)
                {
                    return NotFound();
                }
                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving course: {ex.Message}");
            }
        }

        [HttpPut("{courseId}")]
        public async Task<IActionResult> UpdateCourse(int courseId, [FromBody] Course course)
        {
            try
            {
                await _courseRepository.UpdateCourseAsync(courseId, course);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating course: {ex.Message}");
            }
        }

        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            try
            {
                await _courseRepository.DeleteCourseAsync(courseId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting course: {ex.Message}");
            }
        }
    }
}