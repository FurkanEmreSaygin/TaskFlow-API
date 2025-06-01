using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskFlow.DataAccess.Db;
using TaskFlow.DataAccess.Interfaces;
using TaskFlow.Entities;

namespace TaskFlow.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskFlowDbContext _repo;

        public UserRepository(TaskFlowDbContext repo)
        {
            _repo = repo;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _repo.Users.FindAsync(id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _repo.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repo.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _repo.Users.AddAsync(user);
        }

        public void Update(User user)
        {
            _repo.Users.Update(user);
        }

        public void Delete(User user)
        {
            _repo.Users.Remove(user);
        }
    }
}