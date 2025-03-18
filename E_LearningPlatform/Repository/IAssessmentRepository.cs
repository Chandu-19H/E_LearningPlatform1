using E_LearningPlatform.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LearningPlatform.Repository
{
    public interface IAssessmentRepository
    {
        Task<IEnumerable<Assessment>> GetAllAsync();
        Task<Assessment> GetByIdAsync(int id);
        Task AddAsync(Assessment assessment);
        Task UpdateAsync(Assessment assessment);
        Task DeleteAsync(int id);
    }
}