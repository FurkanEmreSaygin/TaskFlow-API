using TaskFlow.Business.Interfaces;
using TaskFlow.DataAccess.Interfaces;
using TaskFlow.Entities;

namespace TaskFlow.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddAsync(User user)
        {
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
            _userRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
            _userRepository.SaveChangesAsync();
        }
    }
}
