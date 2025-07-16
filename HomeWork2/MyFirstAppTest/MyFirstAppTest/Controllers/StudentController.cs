using Microsoft.AspNetCore.Mvc;
using MyFirstAppTest.Data;
using MyFirstAppTest.Models;

namespace MyFirstAppTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(FakeDb.Students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = FakeDb.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound("Student topilmadi.");
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student student) 
        {
            student.Id = FakeDb.Students.Max(x => x.Id) + 1;
            FakeDb.Students.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student updatedstudent) 
        {
            var student = FakeDb.Students.FirstOrDefault(x => x.Id == id);
            if (student == null) 
            {
                return NotFound("Student topilmadi.");
            }

            student.FullName = updatedstudent.FullName;
            student.Age = updatedstudent.Age;
            student.Course = updatedstudent.Course;

            return Ok(student);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id) 
        {
            var student = FakeDb.Students.FirstOrDefault(x => x.Id == id);
            if (student == null) 
            {
                return NotFound("Student topilmadi.");
            }

            FakeDb.Students.Remove(student);
            return NoContent();
        }
    }
}
