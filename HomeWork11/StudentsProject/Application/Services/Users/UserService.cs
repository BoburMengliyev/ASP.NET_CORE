using Students.Domain.Models;
using Students.Infrastructure.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository) 
        {
            this.userRepository = userRepository;
        }

        public async Task<List<User>> GetAllStudent() 
        {
            return await this.userRepository.GetAllAsync();
        }

        public async Task<User> GetByNameAsync(string FirstName) 
        {
            if (FirstName is null) 
            {
                throw new ArgumentNullException("User is not found");
            }

            return await this.userRepository.GetByNameAsync(FirstName);
        }

        public async Task<User> AddUserAsync(User user)
        {
            if (user is null) 
            {
                throw new ArgumentNullException("User is not found");
            }

            user.Id = Guid.NewGuid();
            return await this.userRepository.InsertUserAsync(user);
        }

        public async Task<User> UpdateUserAsync(User user) 
        {
            return await userRepository.UpdateUserAsync(user);
        }

        public async Task<string> DeleteUserAsync(Guid Id) 
        {
            return await userRepository.DeleteUserAsync(Id);
        }
    }
}