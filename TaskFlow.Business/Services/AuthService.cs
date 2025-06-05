using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFlow.Business.DTOs;
using TaskFlow.Business.Interfaces;
using TaskFlow.DataAccess.Interfaces;
using TaskFlow.Entities;

namespace TaskFlow.Business.Services
{
    public class AuthService : IAuthService
    {
        private static UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email
            };
        }
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> RegisterAsync(RegisterRequestDto request)
        {
            var existing = await _userRepository.GetByEmailAsync(request.Email);
            if (existing != null) return null;

            var user = new User
            {
                Email = request.Email,
                PasswordHash = request.Password
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return MapToDto(user);
        }

        public async Task<UserDto?> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || user.PasswordHash != request.Password)
                return null;

            return MapToDto(user);
        }
    }
}