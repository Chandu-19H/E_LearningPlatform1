using E_LearningPlatform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_LearningPlatform.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace E_LearningPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionRepository _repository;

        public SubmissionController(ISubmissionRepository repository)
        {
            _repository = repository;
        }
       
        [HttpGet("GetAllSubmissions")]
        public async Task<ActionResult<IEnumerable<Submission>>> GetAllSubmissions()
        {
            var submissions = await _repository.GetAllSubmissionsAsync();
            return Ok(submissions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Submission>> GetSubmissionById(int id)
        {
            var submission = await _repository.GetSubmissionByIdAsync(id);
            if (submission == null)
            {
                return NotFound();
            }
            return Ok(submission);
        }
       
        [HttpPost]
        public async Task<ActionResult<Submission>> PostSubmission([FromBody] Submission submission)
        {
            await _repository.AddSubmissionAsync(submission);
            return CreatedAtAction(nameof(GetSubmissionById), new { id = submission.SubmissionId }, submission);
        }
      
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubmission(int id, [FromBody] Submission submission)
        {
            if (id != submission.SubmissionId)
            {
                return BadRequest();
            }

            await _repository.UpdateSubmissionAsync(submission);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubmission(int id)
        {
            await _repository.DeleteSubmissionAsync(id);
            return NoContent();
        }
    }
}