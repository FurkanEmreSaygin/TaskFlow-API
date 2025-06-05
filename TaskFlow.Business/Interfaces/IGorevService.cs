using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFlow.Business.DTOs;
using TaskFlow.Entities;

namespace TaskFlow.Business.Interfaces
{
    public interface IGorevService
    {
        Task<GorevDto?> GetByIdAsync(int id);
        Task<IEnumerable<Gorev>> GetAllAsync();
        Task<IEnumerable<GorevDto>> GetByUserIdAsync(int userId);
        Task<Gorev?> GetEntityByIdAsync(int id);
        Task AddAsync(GorevAddDto gorev);
        Task<bool> UpdateAsync(int id, GorevUpdateDto dto);
        void Delete(Gorev gorev);
    }
}