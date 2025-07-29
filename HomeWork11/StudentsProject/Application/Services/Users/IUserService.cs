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
        public Task <List<User>> GetAllStudent();
        public Task <User> AddUserAsync (User user);
        public Task<User> GetByNameAsync(string FirstName);
        public Task<User> UpdateUserAsync(User user);
        public Task<string> DeleteUserAsync(Guid Id);
    }
}
