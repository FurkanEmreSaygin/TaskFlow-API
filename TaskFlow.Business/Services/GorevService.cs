using TaskFlow.Business.Interfaces;
using TaskFlow.DataAccess.Interfaces;
using TaskFlow.Entities;

namespace TaskFlow.Business.Services
{
    public class GorevService : IGorevService
    {
        private readonly IGorevRepository _gorevRepository;

        public GorevService(IGorevRepository gorevRepository)
        {
            _gorevRepository = gorevRepository;
        }

        public async Task AddAsync(Gorev gorev)
        {
            await _gorevRepository.AddAsync(gorev);
        }

        public void Delete(Gorev gorev)
        {
            _gorevRepository.Delete(gorev);
        }

        public async Task<IEnumerable<Gorev>> GetAllAsync()
        {
            return await _gorevRepository.GetAllAsync();
        }

        public async Task<Gorev?> GetByIdAsync(int id)
        {
            return await _gorevRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Gorev>> GetByUserIdAsync(int userId)
        {
            return await _gorevRepository.GetByUserIdAsync(userId);
        }

        public void Update(Gorev gorev)
        {
            _gorevRepository.Update(gorev);
        }
    }
}
