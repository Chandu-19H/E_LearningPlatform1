using E_LearningPlatform.Models;
using E_LearningPlatform.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace E_LearningPlatform.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private ELearningDbContext _enrollments;

        public EnrollmentRepository(ELearningDbContext enrollments)
        {
            _enrollments = enrollments;
        }

        public async Task AddEnrollmentAsync(Enrollment enrollment)
        {
            await _enrollments.AddAsync(enrollment);
            await _enrollments.SaveChangesAsync();
        }

        public async Task DeleteEnrollmentAsync(int id)
        {
            var enrollment = await GetEnrollmentByIdAsync(id);
            if (enrollment != null)
            {
                _enrollments.Remove(enrollment);
                await _enrollments.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _enrollments.Enrollments.ToListAsync();
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(int id)
        {
            return await _enrollments.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentId == id);
        }

        public async Task UpdateEnrollmentAsync(Enrollment enrollment)
        {
            var existingEnrollment = await GetEnrollmentByIdAsync(enrollment.EnrollmentId);
            if (existingEnrollment != null)
            {
                existingEnrollment.StudentId = enrollment.StudentId;
                existingEnrollment.CourseId = enrollment.CourseId;
                existingEnrollment.Progress = enrollment.Progress;
                await _enrollments.SaveChangesAsync();
            }
        }

        public async Task UpdateProgressAsync(int enrollmentId, double progress)
        {
            var enrollment = await _enrollments.Enrollments.FindAsync(enrollmentId);
            if (enrollment != null)
            {
                enrollment.Progress = progress;
                await _enrollments.SaveChangesAsync();
            }
        }
        public async Task<bool> StudentExistsAsync(int studentId)
        {
            return await _enrollments.Students.AnyAsync(s => s.StudentId == studentId);
        }
    }
}