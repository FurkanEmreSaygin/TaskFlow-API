using TaskFlow.Business.DTOs;
using TaskFlow.Business.Interfaces;
using TaskFlow.DataAccess.Interfaces;
using TaskFlow.Entities;

namespace TaskFlow.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private static UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role,
                Gorevler = user.Gorevler.Select(g => new GorevDto
                {
                    Id = g.Id,
                    Baslik = g.Baslik,
                    Aciklama = g.Aciklama,
                    Tarih = g.Tarih,
                    TamamlandiMi = g.TamamlandiMi
                }).ToList()
            };
        }
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

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role,
                Gorevler = user.Gorevler.Select(g => new GorevDto
                {
                    Id = g.Id,
                    Baslik = g.Baslik,
                    Aciklama = g.Aciklama,
                    Tarih = g.Tarih,
                    TamamlandiMi = g.TamamlandiMi
                }).ToList()
            });
        }

        public async Task<UserDto?> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return user == null ? null : MapToDto(user);
        }
        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : MapToDto(user);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
            _userRepository.SaveChangesAsync();
        }
    }
}
