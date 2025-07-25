using Dapper;
using Npgsql;
using System.Data;
using Workplace.Domain.Models;

namespace Workplace.Infrastructure.Services.Companys
{
    public class CompanyService : ICompanyService
    {
        private readonly string _connectionString;

        public CompanyService()
        {
            _connectionString = "Host=localhost;Port=5432;Database=testcompanydb;Username=postgres;Password=2616";
        }

        public async Task<List<Company>> GetAllAsync()
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = "SELECT * FROM companies";
            var companies = await db.QueryAsync<Company>(sql);
            return companies.ToList();
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = "SELECT * FROM companies WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Company>(sql, new { Id = id });
        }

        public async Task<Company> CreateAsync(Company company)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = @"
                INSERT INTO companies (name)
                VALUES (@Name)
                RETURNING *;";

            var created = await db.QuerySingleAsync<Company>(sql, company);
            return created;
        }

        public async Task<bool> UpdateAsync(Company company)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = @"
                UPDATE companies
                SET name = @Name,
                    address = @Address
                WHERE id = @Id";

            var affected = await db.ExecuteAsync(sql, company);
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = "DELETE FROM companies WHERE id = @Id";
            var affected = await db.ExecuteAsync(sql, new { Id = id });
            return affected > 0;
        }
    }
}
