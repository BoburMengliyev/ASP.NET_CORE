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

        public async Task<IEnumerable<User>> SelectAllUsersAsync() 
        {
            var selectSql =
                """
                SELECT 
                    id,
                    first_name as FirstName,
                    last_name as LastName,
                    address,
                    created_date as CreatedDate,
                    updated_date as UpdatedDate
                FROM "User";
                """;

             return await this.applicationDbContext.Connection.QueryAsync<User>(selectSql);
        }

        public async Task<User> SelectUserByIdAsync(Guid userId) 
        {
            string selectSql=
                """"
                SELECT 
                    id,
                    first_name as FirstName,
                    last_name as LastName,
                    address,
                    created_date as CreatedDate,
                    updated_date as UpdatedDate
                FROM "User"
                WHERE id = @userId
                """";

            return await this.applicationDbContext.Connection.QueryFirstOrDefaultAsync<User>(
                selectSql, new { userId });
        }

        public async Task<User> InsertUserAsync(User user) 
        {
            string insertSql =
                """
                INSERT INTO "User"(Id, first_name, last_name, address, created_date, updated_date)
                VALUES(@Id, @FirstName, @LastName, @Address, @CreatedDate, @UpdatedDate)
                """;

            await this.applicationDbContext.Connection.ExecuteAsync(insertSql, user);
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            string updateUser =
                """
        UPDATE "User" 
        SET
            first_name = @FirstName,
            last_name = @LastName,
            address = @Address
        WHERE id = @Id;
        """;

            await this.applicationDbContext.Connection.ExecuteAsync(updateUser, user);
            return user;
        }

        public async Task DeleteUserByIdAsync(Guid userId) 
        {
            string deleteUser =
                """
                DELETE FROM "User"
                WHERE id = @userId
                """;

            await this.applicationDbContext.Connection.ExecuteAsync(deleteUser, new { userId } );
        }
    }
}