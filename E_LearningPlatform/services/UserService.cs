using E_LearningPlatform.Models;
using E_LearningPlatform.Repository;
using E_LearningPlatform.Exceptions;

namespace E_LearningPlatform.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new DetailsNotFoundException($"User with id {userId} does not exist");
            }
            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                throw new DetailsNotFoundException($"User with email {email} does not exist");
            }
            return user;
        }

        public async Task AddUserAsync(User user)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(user.UserID);
            if (existingUser != null)
            {
                throw new DetailsAlreadyExistsException($"User with id {user.UserID} already exists");
            }
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(user.UserID);
            if (existingUser == null)
            {
                throw new DetailsNotFoundException($"User with id {user.UserID} does not exist");
            }
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new DetailsNotFoundException($"User with id {userId} does not exist");
            }
            await _userRepository.DeleteUserAsync(userId);
        }
    }
}
