using Students.Domain.DTOs.Users;
using Students.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Application.Services.Users
{
    public interface IUserService
    {
        Task <CreateUserDto> AddUserAsync (CreateUserDto createUserDto);
        Task <IEnumerable<GetUserDto>> RetrieveAllUsersAsync();
        Task<GetUserDto> ModifyUserAsync(UpdateUserDto updateUserDto);
        Task<GetUserDto> RemoveByIdUserAsync(Guid userId);
        Task<User> GetByIdAsync(Guid userId);
    }
}
