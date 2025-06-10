using TaskFlow.Business.DTOs;
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

        private static GorevDto MapToDto(Gorev gorev)
        {
            return new GorevDto
            {
                Id = gorev.Id,
                Baslik = gorev.Baslik,
                Aciklama = gorev.Aciklama,
                Tarih = gorev.Tarih,
                TamamlandiMi = gorev.TamamlandiMi
            };
        }

        public async Task<GorevDto?> GetByIdAsync(int id)
        {
            var gorev = await _gorevRepository.GetByIdAsync(id);
            return gorev == null ? null : MapToDto(gorev);
        }

        public async Task<IEnumerable<Gorev>> GetAllAsync()
        {
            return await _gorevRepository.GetAllAsync();
        }

        public async Task<IEnumerable<GorevDto>> GetByUserIdAsync(int userId)
        {
            var gorevler = await _gorevRepository.GetByUserIdAsync(userId);
            return gorevler.Select(MapToDto);
        }

        public async Task<Gorev?> GetEntityByIdAsync(int id)
        {
            return await _gorevRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(GorevAddDto dto)
        {
            var entity = new Gorev
            {
                Baslik = dto.Baslik,
                Aciklama = dto.Aciklama,
                Tarih = dto.Tarih,
                TamamlandiMi = dto.TamamlandiMi,
                UserId = dto.UserId
            };

            await _gorevRepository.AddAsync(entity);
            await _gorevRepository.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(int id, GorevUpdateDto dto)
        {
            var gorev = await _gorevRepository.GetByIdAsync(id);
            if (gorev == null)
                return false;

            gorev.Baslik = dto.Baslik;
            gorev.Aciklama = dto.Aciklama;
            gorev.TamamlandiMi = dto.TamamlandiMi;
            _gorevRepository.Update(gorev);
            await _gorevRepository.SaveChangesAsync();
            return true;
            // şu an aktif değil
        }
        public void Delete(Gorev gorev)
        {
            _gorevRepository.Delete(gorev);
            _gorevRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateByOwnerAsync(int id, GorevUpdateDto dto, int userId)
        {
            var gorev = await _gorevRepository.GetByIdAsync(id);
            if (gorev == null || gorev.UserId != userId)
            {
                return false;
            }
            gorev.Baslik = dto.Baslik;
            gorev.Aciklama = dto.Aciklama;
            gorev.TamamlandiMi = dto.TamamlandiMi;

            _gorevRepository.Update(gorev);
            await _gorevRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByOwnerAsync(int id, int userId)
        {
            var gorev = await _gorevRepository.GetByIdAsync(id);
            if (gorev == null || gorev.UserId != userId)
            {
                return false;
            }

            _gorevRepository.Delete(gorev);
            await _gorevRepository.SaveChangesAsync();
            return true;
        }
    }
}
