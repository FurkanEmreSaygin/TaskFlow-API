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

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(int userId)
        {
            var gorevler = await _service.GetByUserIdAsync(userId);
            return Ok(gorevler);
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var gorev = await _service.GetByIdAsync(id);
            if (gorev == null)
                return NotFound("Görev bulunamadı.");

            return Ok(gorev);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GorevAddDto dto)
        {
            await _service.AddAsync(dto);
            return Ok("Görev oluşturuldu.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GorevUpdateDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success)
                return NotFound("Görev bulunamadı.");

            return Ok("Görev güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var gorev = await _service.GetEntityByIdAsync(id);
            if (gorev == null)
                return NotFound("Görev bulunamadı.");

            _service.Delete(gorev);
            return Ok("Görev silindi.");
        }
    }
}
