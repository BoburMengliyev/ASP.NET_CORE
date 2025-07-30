using Students.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Infrastructure.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> InsertUserAsync(User user);
        Task<IEnumerable<User>> SelectAllUsersAsync();
        Task<User> SelectUserByIdAsync(Guid userId);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserByIdAsync(Guid userId);
    }
}
