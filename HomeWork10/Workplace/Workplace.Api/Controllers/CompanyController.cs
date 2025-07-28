using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Workplace.Domain.Models;
using Workplace.Infrastructure.Services.Companys;

namespace Workplace.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private const string connectionString = "Host=localhost;Port=5432;Database=testcompanydb;Username=postgres;Password=2616";


        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _companyService.GetAllAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
                return NotFound();
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Company company)
        {
            await _companyService.CreateAsync(company);
            return CreatedAtAction(nameof(GetById), new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Company company)
        {
            if (id != company.Id)
                return BadRequest();

            await _companyService.UpdateAsync(company);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _companyService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("company-with-branches")]
        public async Task<ActionResult<Company>> GetCompanyWithBranchesAsync(int companyId)
        {
            string sql = """
        SELECT * FROM companies WHERE id = @companyId;
        SELECT * FROM branches WHERE company_id = @companyId;
    """;

            using var connection = new NpgsqlConnection(connectionString);
            using var multi = await connection.QueryMultipleAsync(sql, new { companyId });

            var company = await multi.ReadFirstOrDefaultAsync<Company>();
            if (company == null) return NotFound();

            company.Branches = (await multi.ReadAsync<Branch>()).ToList();

            return Ok(company);
        }

    }
}
