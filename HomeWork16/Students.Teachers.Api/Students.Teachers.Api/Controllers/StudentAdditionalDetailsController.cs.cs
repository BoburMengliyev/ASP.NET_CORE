using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.Teachers.Api.Data;
using Students.Teachers.Api.Models;

namespace Students.Teachers.Api.Controllers
{
    [ApiController]
    [Route("api/students-additional-details")]
    public class StudentAdditionalDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentAdditionalDetailsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<StudentAdditionalDetail>> PostAsync(
            [FromBody] StudentAdditionalDetail studentAdditionalDetail)
        {
            await this.applicationDbContext.AddAsync(studentAdditionalDetail);
            await this.applicationDbContext.SaveChangesAsync();

            return Ok(studentAdditionalDetail);
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentAdditionalDetail>>> GetAllAsync()
        {
            List<StudentAdditionalDetail> details =
                await this.applicationDbContext.StudentAdditionalDetails
                    .Include(studentAdditionalDetail => studentAdditionalDetail.Student)
                        .ToListAsync();

            return Ok(details);
        }
    }
}
