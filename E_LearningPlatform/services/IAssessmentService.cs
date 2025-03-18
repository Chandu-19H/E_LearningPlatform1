using E_LearningPlatform.Models;

namespace E_LearningPlatform.Services
{
    public interface IAssessmentService
    {
        Task<IEnumerable<Assessment>> GetAllAsync();
        Task<Assessment> GetByIdAsync(int id);
        Task AddAsync(Assessment assessment);
        Task UpdateAsync(Assessment assessment);
        Task DeleteAsync(int id);
    }
}