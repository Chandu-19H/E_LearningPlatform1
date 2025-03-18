using E_LearningPlatform.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LearningPlatform.Repository
{
    public interface ISubmissionRepository
    {
        Task<IEnumerable<Submission>> GetAllSubmissionsAsync();
        Task<Submission> GetSubmissionByIdAsync(int id);
        Task AddSubmissionAsync(Submission submission);
        Task UpdateSubmissionAsync(Submission submission);
        Task DeleteSubmissionAsync(int id);
    }
}