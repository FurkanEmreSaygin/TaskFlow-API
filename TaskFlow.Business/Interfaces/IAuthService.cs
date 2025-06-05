using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFlow.Business.DTOs;
using TaskFlow.Entities;

namespace TaskFlow.Business.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto?> RegisterAsync(RegisterRequestDto request);
        Task<UserDto?> LoginAsync(LoginRequestDto request);

    }
}