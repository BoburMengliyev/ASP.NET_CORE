using BankExamAPI.Models;
using BankExamAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankExamAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;

        public AccountController(IAccountService accountService, ICustomerService customerService)
        {
            _accountService = accountService;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _accountService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var account = await _accountService.GetByIdAsync(id);
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            var customer = await _customerService.GetByIdAsync(customerId);
            if (customer == null) return NotFound("Mijoz topilmadi");
            var accounts = await _accountService.GetByCustomerIdAsync(customerId);
            return Ok(accounts);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Account account)
        {
            try
            {
                var customer = await _customerService.GetByIdAsync(account.CustomerId);
                if (customer == null) return BadRequest("Bunday mijoz mavjud emas");

                var created = await _accountService.CreateAsync(account);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server xatosi: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Account account)
        {
            try
            {
                var updated = await _accountService.UpdateAsync(id, account);
                if (updated == null) return NotFound();
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server xatosi: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _accountService.DeleteAsync(id);
                if (!deleted) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Xatolik: {ex.Message}");
            }
        }
    }

}
