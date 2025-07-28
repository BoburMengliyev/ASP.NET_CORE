using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Workplace.Domain.Models;
using Workplace.Infrastructure.Services.Branchs;

namespace Workplace.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        private const string connectionString = "Host=localhost;Port=5432;Database=testcompanydb;Username=postgres;Password=2616";


        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var branches = await _branchService.GetAllAsync();
            return Ok(branches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var branch = await _branchService.GetByIdAsync(id);
            if (branch == null)
                return NotFound();
            return Ok(branch);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Branch branch)
        {
            var created = await _branchService.CreateAsync(branch);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Branch branch)
        {
            if (id != branch.Id)
                return BadRequest("ID mismatch");

            var result = await _branchService.UpdateAsync(branch);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _branchService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpGet("branch-with-employees")]
        public async Task<ActionResult<Branch>> GetBranchWithEmployeesAsync(int branchId)
        {
            string sql = """
        SELECT * FROM branches WHERE id = @branchId;
        SELECT * FROM employees WHERE branch_id = @branchId;
    """;

            using var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();

            using var multi = await connection.QueryMultipleAsync(sql, new { branchId });

            var branch = await multi.ReadFirstOrDefaultAsync<Branch>();
            if (branch == null) return NotFound();

            branch.Employees = (await multi.ReadAsync<Employee>()).ToList();

            return Ok(branch);
        }

    }
}
