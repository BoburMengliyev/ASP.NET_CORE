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
        public Task<List<User>> GetAllAsync();
        public Task<User> InsertUserAsync(User user);
        public Task<User> GetByNameAsync(string FirstName);
        public Task<User> UpdateUserAsync(User user);
        public Task<string> DeleteUserAsync(Guid Id);
    }
}
