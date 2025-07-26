using Microsoft.AspNetCore.Mvc;
using ExamDapperOrm.Domain.Models;
using ExamDapperOrm.Infrastructure.Services;

namespace ExamDapperOrm.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassportController : ControllerBase
    {
        private readonly IPassportRepository _passportRepository;

        public PassportController(IPassportRepository passportRepository)
        {
            _passportRepository = passportRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var passports = await _passportRepository.GetAllAsync();
            return Ok(passports);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var passport = await _passportRepository.GetByIdAsync(id);
            if (passport is null)
                return NotFound($"Passport ID {id} topilmadi.");

            return Ok(passport);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Passport passport)
        {
            var created = await _passportRepository.CreateAsync(passport);
            if (!created)
                return BadRequest("Passport yartilmadi .");
            return Ok(passport);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Passport passport)
        {
            passport.Id = id;
            var updated = await _passportRepository.UpdateAsync(passport);
            if (!updated)
                return NotFound($"Passport ID {id}topilmadi va yangilanmadi.");
            return Ok(passport);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _passportRepository.DeleteAsync(id);
            if (!deleted)
                return NotFound($"Passport ID {id} topilmadi va o`chirilmadi.");
            return Ok($"Passport ID {id} o`chirildi.");
        }
    }
}
