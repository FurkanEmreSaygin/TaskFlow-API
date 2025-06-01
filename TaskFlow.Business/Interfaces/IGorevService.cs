using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFlow.Entities;

namespace TaskFlow.Business.Interfaces
{
    public interface IGorevService
    {
        Task<Gorev?> GetByIdAsync(int id);
        Task<IEnumerable<Gorev>> GetAllAsync();
        Task<IEnumerable<Gorev>> GetByUserIdAsync(int userId);
        Task AddAsync(Gorev gorev);
        void Update(Gorev gorev);
        void Delete(Gorev gorev);
    }
}