using Microsoft.AspNetCore.Mvc;
using UProject.Data;
using UProject.Models;

namespace UProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext aplicationDbContext;

        public UsersController(ApplicationDbContext applicationDbContext)
        {
            this.aplicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUserAsync(User user) 
        {
            await this.aplicationDbContext.Users.AddAsync(user);
            
            await this.aplicationDbContext.SaveChangesAsync();

            return Ok(user);
        }
    }
}
