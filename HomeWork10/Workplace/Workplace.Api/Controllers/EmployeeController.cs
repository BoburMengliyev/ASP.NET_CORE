using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Workplace.Domain.Models;
using Workplace.Infrastructure.Services.Employees;

namespace Workplace.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private const string connectionString = "Host=localhost;Port=5432;Database=testcompanydb;Username=postgres;Password=2616";

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            var created = await _employeeService.CreateAsync(employee);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
                return BadRequest("ID mismatch");

            var result = await _employeeService.UpdateAsync(employee);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _employeeService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
        [HttpGet("employee-details")]
        public async Task<ActionResult<Employee>> GetEmployeeWithDetailsAsync(int employeeId)
        {
            string sql = """
        SELECT 
            e.id, e.first_name, e.last_name, e.email, 
            e.department_id, e.branch_id, e.company_id,
            
            b.id, b.location, b.company_id,
            d.id, d.name, d.company_id,
            c.id, c.name
            
        FROM employees e
        JOIN branches b ON e.branch_id = b.id
        JOIN departments d ON e.department_id = d.id
        JOIN companies c ON e.company_id = c.id
        WHERE e.id = @employeeId;
    """;

            using var connection = new NpgsqlConnection(connectionString);

            var result = await connection.QueryAsync<Employee, Branch, Department, Company, Employee>(
                sql,
                (employee, branch, department, company) =>
                {
                    employee.Branch = branch;
                    employee.Department = department;
                    employee.Company = company;
                    return employee;
                },
                new { employeeId },
                splitOn: "id,id,id"
            );

            var employeeResult = result.FirstOrDefault();
            if (employeeResult == null) return NotFound();

            return Ok(employeeResult);
        }
    }
}
