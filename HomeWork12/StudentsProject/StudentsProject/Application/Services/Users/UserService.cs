using Students.Domain.DTOs.Users;
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

        public async Task<IEnumerable<GetUserDto>> RetrieveAllUsersAsync() 
        {
            IEnumerable<User> users =
                await this.userRepository.SelectAllUsersAsync();

            return users.Select(user => new GetUserDto 
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate
            });
        }

        public async Task<GetUserDto> ModifyUserAsync(UpdateUserDto updateUserDto) 
        {
            User maybeUser = 
                await this.userRepository.SelectUserByIdAsync(updateUserDto.Id);

            if (maybeUser is null) 
            {
                throw new KeyNotFoundException($"User is not found with given id: {updateUserDto.Id}");
            }

            User user = new User
            {
                Id = maybeUser.Id,
                FirstName = updateUserDto.FirstName,
                LastName = updateUserDto.LastName,
                Address = maybeUser.Address,
                CreatedDate = maybeUser.CreatedDate,
                UpdatedDate = DateTimeOffset.UtcNow
            };
            await this.userRepository.UpdateUserAsync(user);
            return new GetUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate
            };
        }

        public async Task<CreateUserDto> AddUserAsync(CreateUserDto createUserDto)
        {
            if (createUserDto is null) 
            {
                throw new ArgumentNullException("User is not found");
            }

            DateTimeOffset now = DateTimeOffset.UtcNow;

            User user = new User 
            { 
                Id = Guid.NewGuid(),
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Address = createUserDto.Address,
                CreatedDate = now,
                UpdatedDate = now
            };

            await this.userRepository.InsertUserAsync(user);

            return createUserDto;
        }

        public async Task<User> UpdateUserAsync(User user) 
        {
            return await userRepository.UpdateUserAsync(user);
        }

        public async Task<GetUserDto> RemoveByIdUserAsync(Guid userId) 
        {
            User maybeUser =
                await this.userRepository.SelectUserByIdAsync(userId);

            if (maybeUser is null)
            {
                throw new KeyNotFoundException($"User is not found with given id: {userId}");
            }

            await this.userRepository.DeleteUserByIdAsync(userId);

            return new GetUserDto 
            {
                Id = maybeUser.Id,
                FirstName = maybeUser.FirstName,
                LastName = maybeUser.LastName,
                CreatedDate = maybeUser.CreatedDate,
                UpdatedDate = maybeUser.UpdatedDate
            };
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            User maybeUser =
               await this.userRepository.SelectUserByIdAsync(userId);

            if (maybeUser is null)
            {
                throw new KeyNotFoundException($"User is not found with given id: {userId}");
            }

            return maybeUser;
        }
    }
}