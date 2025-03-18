using E_LearningPlatform.Models;

namespace E_LearningPlatform.Repository
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync();
        Task<Enrollment> GetEnrollmentByIdAsync(int id);
        Task AddEnrollmentAsync(Enrollment enrollment);
        Task UpdateEnrollmentAsync(Enrollment enrollment);
        Task DeleteEnrollmentAsync(int id);
        Task UpdateProgressAsync(int enrollmentId, double progress);
    }
}