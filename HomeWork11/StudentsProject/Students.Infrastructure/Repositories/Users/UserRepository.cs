using Dapper;
using Students.Domain.Models;
using Students.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UserRepository(ApplicationDbContext applicationDbContext) 
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<User>> GetAllAsync() 
        {
            var selectSql =
                """
                SELECT * FROM "User";
                """;

            var result  = await this.applicationDbContext.Connection.QueryAsync<User>(selectSql);
            return result.ToList();
        }

        public async Task<User> GetByNameAsync(string FirstName) 
        {
            string selectSql=
                """
                SELECT * FROM "User" WHERE first_name = @FirstName
                """;
            
            var result = await this.applicationDbContext.Connection.QueryFirstOrDefaultAsync<User>(selectSql, new { FirstName});
            return result;
        }

        public async Task<User> InsertUserAsync(User user) 
        {
            string insertSql =
                """
                INSERT INTO "User"(Id, first_name, last_name, address)
                VALUES(@Id, @FirstName, @LastName, @Address)
                """;

            await this.applicationDbContext.Connection.ExecuteAsync(insertSql, user);
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            string updateUser =
            """
            UPDATE "User" 
            SET first_name = @FirstName,
                last_name = @LastName,
                address = @Address
            WHERE id = @Id;
            """;

            await this.applicationDbContext.Connection.ExecuteAsync(updateUser, user);
            return user;
        }

        public async Task<string> DeleteUserAsync(Guid Id) 
        {
            string deleteUser =
                """
                DELETE FROM "User"
                WHERE id = @Id
                """;

            await this.applicationDbContext.Connection.ExecuteAsync(deleteUser, new { Id });
            return "User o`chirildi";
        }
    }
}