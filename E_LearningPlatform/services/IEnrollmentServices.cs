using E_LearningPlatform.Models;

namespace E_LearningPlatform.Services
{
    public interface IEnrollmentServices
    {
        Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync();
        Task<Enrollment> GetEnrollmentByIdAsync(int enrollmentId);
        Task AddEnrollmentAsync(Enrollment enrollment);
        Task UpdateEnrollmentAsync(int id, Enrollment enrollment);
        Task DeleteEnrollmentAsync(int id);
        Task UpdateProgressAsync(int enrollmentId, double progress);

    }
}