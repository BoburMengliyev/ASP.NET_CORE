using Microsoft.AspNetCore.Mvc;
using Workplace.Domain.Models;
using Workplace.Infrastructure.Services.Branchs;

namespace Workplace.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

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
    }
}
