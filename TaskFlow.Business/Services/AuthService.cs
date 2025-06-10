using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
                Email = user.Email,
                Role = user.Role
            };
        }
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository, IConfiguration config)
        {
            _config = config;
            _userRepository = userRepository;
        }

        public async Task<UserDto?> RegisterAsync(RegisterRequestDto request)
        {
            var existing = await _userRepository.GetByEmailAsync(request.Email);
            if (existing != null) return null;

            var user = new User
            {
                Email = request.Email,
                PasswordHash = request.Password,
                Role = request.Role
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return MapToDto(user);
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:ExpireMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<UserDto?> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || user.PasswordHash != request.Password)
                return null;

            var dto = MapToDto(user);
            dto.Token = GenerateJwtToken(user); // token'ı UserDto'ya koy

            return dto;
        }
    }
}