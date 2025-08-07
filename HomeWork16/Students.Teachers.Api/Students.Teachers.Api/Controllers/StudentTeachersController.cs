using Microsoft.AspNetCore.Mvc;
using Students.Teachers.Api.Data;
using Students.Teachers.Api.Models;

namespace Students.Teachers.Api.Controllers
{
    [ApiController]
    [Route("api/student-controllers")]
    public class StudentTeachersController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentTeachersController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<StudentTeacher>> PostAsync(StudentTeacher studentTeacher)
        {
            await this.applicationDbContext.StudentTeachers.AddAsync(studentTeacher);
            await this.applicationDbContext.SaveChangesAsync();

            return Ok(studentTeacher);
        }
    }
}
