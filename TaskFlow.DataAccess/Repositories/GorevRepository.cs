using Microsoft.EntityFrameworkCore;
using TaskFlow.DataAccess.Db;
using TaskFlow.DataAccess.Interfaces;
using TaskFlow.Entities;

namespace TaskFlow.DataAccess.Repositories
{
    public class GorevRepository : IGorevRepository
    {
        private readonly TaskFlowDbContext _repo;

        public GorevRepository(TaskFlowDbContext repo)
        {
            _repo = repo;
        }

        public async Task<Gorev?> GetByIdAsync(int id)
        {
            return await _repo.Gorevler.FindAsync(id);
        }

        public async Task<IEnumerable<Gorev>> GetAllAsync()
        {
            return await _repo.Gorevler.ToListAsync();
        }

        public async Task<IEnumerable<Gorev>> GetByUserIdAsync(int userId)
        {
            return await _repo.Gorevler.Where(g => g.UserId == userId).ToListAsync();
        }

        public async Task AddAsync(Gorev gorev)
        {
            await _repo.Gorevler.AddAsync(gorev);
        }

        public void Update(Gorev gorev)
        {
            _repo.Gorevler.Update(gorev);
        }

        public void Delete(Gorev gorev)
        {
            _repo.Gorevler.Remove(gorev);
        }

        public async Task SaveChangesAsync()
        {
            await _repo.SaveChangesAsync();
        }
    }
}
