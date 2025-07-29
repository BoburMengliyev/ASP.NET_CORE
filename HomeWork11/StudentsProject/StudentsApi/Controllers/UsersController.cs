using Microsoft.AspNetCore.Mvc;
using Students.Application.Services.Users;
using Students.Domain.Models;

namespace Students.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetStudentAsync() 
        {
            var getStudents = 
                await this.userService.GetAllStudent();
            return Ok(getStudents);
        }

        [HttpGet("FirstName")]
        public async Task<ActionResult<User>> GetByNameAsync(string FirstName) 
        {
            var getStudent = await this.userService.GetByNameAsync(FirstName);
            return Ok(getStudent);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUserAsync(User user) 
        {
           User addedUser = 
                await this.userService.AddUserAsync(user);

            return Ok(addedUser);
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUserAsync(User user) 
        { 
            var updateUser = 
                await this.userService.UpdateUserAsync(user);
            return Ok(updateUser);
        }

        [HttpDelete]
        public async Task<ActionResult<string>> DeleteUserAsync(Guid Id) 
        {
            var deleteUser = await this.userService.DeleteUserAsync(Id);
            return Ok(deleteUser);
        }
    }
}
