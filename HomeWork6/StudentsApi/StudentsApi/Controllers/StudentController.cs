using Microsoft.AspNetCore.Mvc;
using StudentsApi.Models;
using StudentsApi.Repositories;

namespace StudentsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository repository;

        public StudentController(IStudentRepository repository) => this.repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await repository.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await repository.GetByIdAsync(id);
            if (student is null) return NotFound($"Id {id} bo`yicha talaba topilmadi.");

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            var id = await repository.CreateAsync(student);
            return CreatedAtAction(nameof(GetById), new { id = id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student student) 
        {
            if (id != student.Id) return BadRequest("Id mos emas.");

            var updated = await repository.UpdateAsync(student);
            if (!updated) return NotFound($"Id {id} bo`yicha talaba topilmadi.");

            return Ok("Muvaffaqiyatli yangilandi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
        var deleted = await repository.DeleteAsync(id);
            if (!deleted) return NotFound($"Id {id} bo`yicha talaba topilmadi.");

            return Ok("Muvaffaqiyatli o‘chirildi.");
        }
    }
}