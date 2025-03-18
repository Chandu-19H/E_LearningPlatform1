using E_LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;
using E_LearningPlatform.Data;
using E_LearningPlatform.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LearningPlatform.Repository
{
    public class AssessmentRepository : IAssessmentRepository
    {
        private readonly ELearningDbContext _context;

        public AssessmentRepository(ELearningDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Assessment assessment)
        {
            await _context.Assessments.AddAsync(assessment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment != null)
            {
                _context.Assessments.Remove(assessment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Assessment>> GetAllAsync()
        {
            return await _context.Assessments.ToListAsync();
        }

        public async Task<Assessment> GetByIdAsync(int id)
        {
            return await _context.Assessments.FindAsync(id);
        }

        public async Task UpdateAsync(Assessment assessment)
        {
            var existingAssessment = await GetByIdAsync(assessment.AssessmentId);
            if (existingAssessment != null)

            {
                existingAssessment.CourseId = assessment.CourseId;
                existingAssessment.Maxscore = assessment.Maxscore;
                existingAssessment.Type = assessment.Type;
                await _context.SaveChangesAsync();

            }
        }
    }
}