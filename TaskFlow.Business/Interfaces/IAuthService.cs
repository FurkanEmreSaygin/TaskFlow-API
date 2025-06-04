using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFlow.Entities;

namespace TaskFlow.Business.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(User user);
        Task<bool> LoginAsync(string email, string password);
    }
}