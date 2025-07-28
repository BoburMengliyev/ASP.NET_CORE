using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Workplace.Domain.Models;
using Workplace.Infrastructure.Services.Departments;

namespace Workplace.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private const string connectionString = "Host=localhost;Port=5432;Database=testcompanydb;Username=postgres;Password=2616";

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);
            if (department == null)
                return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Department department)
        {
            var created = await _departmentService.CreateAsync(department);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Department department)
        {
            if (id != department.Id)
                return BadRequest("ID mismatch");

            var result = await _departmentService.UpdateAsync(department);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _departmentService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpGet("department-with-employees")]
        public async Task<ActionResult<Department>> GetDepartmentWithEmployeesAsync(int departmentId)
        {
            string sql =
                """
                    SELECT * FROM departments WHERE id = @departmentId;
                    SELECT * FROM employees WHERE department_id = @departmentId;
                 """;

            using var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();
            using var multi = await connection.QueryMultipleAsync(sql, new { departmentId });

            var department = await multi.ReadFirstOrDefaultAsync<Department>();
            if (department == null) return NotFound();

            department.Employees = (await multi.ReadAsync<Employee>()).ToList();

            return Ok(department);
        }


    }
}
