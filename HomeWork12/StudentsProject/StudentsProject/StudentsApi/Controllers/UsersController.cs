using Microsoft.AspNetCore.Mvc;
using Students.Application.Services.Users;
using Students.Domain.DTOs.Users;
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
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetAllUsersAsync() 
        {
            IEnumerable<GetUserDto> getUserDtos =
                await this.userService.RetrieveAllUsersAsync();

            return Ok(getUserDtos);
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserDto>> PostUserAsync(CreateUserDto createUserDto) 
        {
           CreateUserDto addedUser = 
                await this.userService.AddUserAsync(createUserDto);

            return Ok(addedUser);
        }

        [HttpPut]
        public async Task<ActionResult<GetUserDto>> PutUserAsync(UpdateUserDto updateUserDto) 
        {
            GetUserDto userDto = 
                await this.userService.ModifyUserAsync(updateUserDto);
            return Ok(userDto);
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<GetUserDto>> DeleteUserByIdAsync(Guid userId) 
        {
            GetUserDto userDto =
                await this.userService.RemoveByIdUserAsync(userId);
            return Ok(userDto);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetByIdAsync(Guid userId)
        {
            var user = await this.userService.GetByIdAsync(userId);
            return Ok(user);
        }
    }
}
