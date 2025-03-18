using E_LearningPlatform.Exceptions;
using E_LearningPlatform.Models;
using E_LearningPlatform.Repository;

namespace E_LearningPlatform.Services
{
    public class EnrollmentService : IEnrollmentServices
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            var enrollments = await _enrollmentRepository.GetAllEnrollmentsAsync();
            return enrollments.ToList();
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(int enrollmentId)
        {
            Enrollment enrollment = await _enrollmentRepository.GetEnrollmentByIdAsync(enrollmentId);
            if (enrollment == null)
            {
                throw new DetailsNotFoundException($"Enrollment with id {enrollmentId} does not exist");
            }
            return enrollment;
        }

        public async Task AddEnrollmentAsync(Enrollment enrollment)
        {
            var Addenrollment = await _enrollmentRepository.GetEnrollmentByIdAsync(enrollment.EnrollmentId);
            if (Addenrollment != null)
            {
                throw new DetailsAlreadyExistsException($"Enrollment with id {enrollment.EnrollmentId} already exists");
            }
            await _enrollmentRepository.AddEnrollmentAsync(enrollment);
        }

        public async Task UpdateEnrollmentAsync(int id, Enrollment enrollment)
        {
            var Updateenrollment = await _enrollmentRepository.GetEnrollmentByIdAsync(id);
            if (Updateenrollment == null)
            {
                throw new DetailsNotFoundException($"Enrollment with id {id} does not exist");
            }
            await _enrollmentRepository.UpdateEnrollmentAsync(enrollment);
        }

        public async Task DeleteEnrollmentAsync(int enrollmentId)
        {
            Enrollment Delenrollment = await _enrollmentRepository.GetEnrollmentByIdAsync(enrollmentId);
            if (Delenrollment == null)
            {
                throw new DetailsNotFoundException($"Enrollment with id {enrollmentId} does not exist");
            }
            await _enrollmentRepository.DeleteEnrollmentAsync(enrollmentId);
        }

        public async Task UpdateProgressAsync(int enrollmentId, double progress)
        {
            Enrollment enrollment = await _enrollmentRepository.GetEnrollmentByIdAsync(enrollmentId);
            if (enrollment == null)
            {
                throw new DetailsNotFoundException($"Enrollment with id {enrollmentId} does not exist");
            }
            await _enrollmentRepository.UpdateProgressAsync(enrollmentId, progress);
        }


    }
}