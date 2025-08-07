using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.Teachers.Api.Data;
using Students.Teachers.Api.Models;

namespace Students.Teachers.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudentAsync(Student student)
        {
            this.applicationDbContext.Entry(student).State = EntityState.Added;
            await applicationDbContext.SaveChangesAsync();

            return Ok(student);
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudentsAsync()
        {
            List<Student> students =
                await this.applicationDbContext.Students
                    .Include(student => student.StudentAdditionalDetail)
                        .ToListAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> GetStudentByIdAsync(Guid id)
        {
            Student? student =
                await this.applicationDbContext.Students.FirstOrDefaultAsync(
                    student => student.Id == id);

            if (student is null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpGet("{studentId}/teachers")]
        public async Task<ActionResult<IQueryable>> GetTeachersByStudentIdAsync(Guid studentId)
        {
            IQueryable teachers =
                this.applicationDbContext.StudentTeachers
                    .Where(studentTeacher => studentTeacher.StudentId == studentId)
                    .Include(studentTeacher => studentTeacher.Teacher)
                    .Select(studentTeacher => studentTeacher.Teacher);

            return Ok(teachers);
        }

        [HttpPut]
        public async Task<ActionResult<Student>> PutStudentAsync(Student student)
        {
            Student? maybeStudent =
                await this.applicationDbContext.Students.FirstOrDefaultAsync(
                    student => student.Id == student.Id);

            if (maybeStudent is null)
            {
                return NotFound();
            }

            this.applicationDbContext.Entry(student).State = EntityState.Modified;
            await this.applicationDbContext.SaveChangesAsync();

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudentByIdAsync(Guid id)
        {
            Student? student =
                await this.applicationDbContext.Students.FirstOrDefaultAsync(
                    student => student.Id == id);

            if (student is null)
            {
                return NotFound();
            }

            this.applicationDbContext.Entry(student).State = EntityState.Deleted;
            await this.applicationDbContext.SaveChangesAsync();

            return Ok(student);
        }
    }
}
