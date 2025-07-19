using Microsoft.AspNetCore.Mvc;

namespace HomeWork5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToolsController : ControllerBase
    {
        [HttpGet("random")]
        public IActionResult GetRandom()
        {
            int number = new Random().Next(1, 100);
            return Ok(number);
        }

        [HttpGet("greet")]
        public async Task<IActionResult> GetName([FromQuery] string name)
        {
            return Ok("Salom" + name);
            await Task.Delay(2000);
        }

        [HttpGet("today")]
        public IActionResult GetDate()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            return Ok(date);
        }

        [HttpGet("length")]
        public IActionResult GetLength([FromQuery] string text)
        {
            int length = text.Length;
            return Ok(length);
        }

        [HttpGet("sqrt")]
        public IActionResult GetSqrt([FromQuery] double num)
        {
            double number = Math.Sqrt(num);
            return Ok(number);
        }
    }
}
