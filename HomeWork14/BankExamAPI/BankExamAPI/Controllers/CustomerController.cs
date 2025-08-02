using BankExamAPI.DTOs;
using BankExamAPI.Models;
using BankExamAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankExamAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IWebHostEnvironment _env;

        public CustomerController(ICustomerService customerService, IWebHostEnvironment env)
        {
            _customerService = customerService;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _customerService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCustomerDto dto, IFormFile? profileImage)
        {
            try
            {
                var customer = new Customer
                {
                    FullName = dto.FullName,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber,
                    Address = dto.Address
                };

                if (profileImage != null)
                {
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(profileImage.FileName)}";
                    var path = Path.Combine(_env.WebRootPath, "uploads");
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                    var fullPath = Path.Combine(path, fileName);
                    using var stream = new FileStream(fullPath, FileMode.Create);
                    await profileImage.CopyToAsync(stream);

                    customer.ProfileImagePath = $"/uploads/{fileName}";
                }

                var result = await _customerService.CreateAsync(customer);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Serverda xatolik: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Customer customer)
        {
            try
            {
                var updated = await _customerService.UpdateAsync(id, customer);
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
                var deleted = await _customerService.DeleteAsync(id);
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
