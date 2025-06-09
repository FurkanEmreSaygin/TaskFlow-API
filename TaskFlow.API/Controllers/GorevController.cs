using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Business.DTOs;
using TaskFlow.Business.Interfaces;
using TaskFlow.Entities;

namespace TaskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GorevController : ControllerBase
    {
        private readonly IGorevService _service;

        public GorevController(IGorevService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(int userId)
        {
            var gorevler = await _service.GetByUserIdAsync(userId);
            return Ok(gorevler);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var gorev = await _service.GetByIdAsync(id);
            if (gorev == null)
                return NotFound("Görev bulunamadı.");

            return Ok(gorev);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetMyTasks()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var gorevler = await _service.GetByUserIdAsync(userId);
            return Ok(gorevler);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GorevAddDto dto)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            dto.UserId = userId;

            await _service.AddAsync(dto);
            return Ok("Görev eklendi.");
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GorevUpdateDto dto)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var updated = await _service.UpdateByOwnerAsync(id, dto, userId);
            if (!updated)
                return NotFound("Görev bulunamadı veya güncelleme yetkiniz yok.");
            return Ok("Görev güncellendi.");
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var deleted = await _service.DeleteByOwnerAsync(id, userId);
            if (!deleted)
                return NotFound("Görev bulunamadı veya silme yetkiniz yok.");
            return Ok("Görev silindi.");
        }
    }
}
