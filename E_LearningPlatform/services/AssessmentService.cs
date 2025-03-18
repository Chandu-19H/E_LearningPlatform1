using E_LearningPlatform.Exceptions;
using E_LearningPlatform.Models;
using E_LearningPlatform.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LearningPlatform.Services
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IAssessmentRepository _repo;

        public AssessmentService(IAssessmentRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(Assessment assessment)
        {
            var existingAssessment = await _repo.GetByIdAsync(assessment.AssessmentId);
            if (existingAssessment != null)
            {
                throw new DetailsAlreadyExistsException($"Assessment with id {assessment.AssessmentId} already exists");
            }
            await _repo.AddAsync(assessment);
        }

        public async Task DeleteAsync(int id)
        {
            var existingAssessment = await _repo.GetByIdAsync(id);
            if (existingAssessment == null)
            {
                throw new DetailsNotFoundException($"Assessment with id {id} does not exist");
            }
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Assessment>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Assessment> GetByIdAsync(int id)
        {
            var assessment = await _repo.GetByIdAsync(id);
            if (assessment == null)
            {
                throw new DetailsNotFoundException($"Assessment with id {id} does not exist");
            }
            return assessment;
        }

        public async Task UpdateAsync(Assessment assessment)
        {
            var existingAssessment = await _repo.GetByIdAsync(assessment.AssessmentId);
            if (existingAssessment == null)
            {
                throw new DetailsNotFoundException($"Assessment with id {assessment.AssessmentId} does not exist");
            }
            await _repo.UpdateAsync(assessment);
        }
    }
}