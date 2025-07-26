using Microsoft.AspNetCore.Mvc;
using ExamDapperOrm.Domain.Models;
using ExamDapperOrm.Infrastructure.Services;

namespace ExamDapperOrm.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepository.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student is null)
                return NotFound($"Student  ID {id} topilmadi");

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
           student.Id = student.Id;
            var created = await _studentRepository.CreateAsync(student);
            if (!created)
                return BadRequest("Student yaratilmadi.");
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Student student)
        {
            student.Id = id;
            var updated = await _studentRepository.UpdateAsync(student);
            if (!updated)
                return NotFound($"Student ID {id} topmadi va yangilanmadi.");
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _studentRepository.DeleteAsync(id);
            if (!deleted)
                return NotFound($"Student  ID {id} topilmadi  o`chirilmadi.");
            return Ok($"Student  ID {id} o`chirildi.");
        }
    }
}
