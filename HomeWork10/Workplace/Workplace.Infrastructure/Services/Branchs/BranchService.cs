using Dapper;
using Npgsql;
using System.Data;
using Workplace.Domain.Models;
using Workplace.Infrastructure.Services.Branchs;

namespace Workplace.Infrastructure.Services.Branches
{
    public class BranchService : IBranchService
    {
        private readonly string _connectionString;

        public BranchService()
        {
            _connectionString = "Host=localhost;Port=5432;Database=testcompanydb;Username=postgres;Password=2616";
        }

        public async Task<List<Branch>> GetAllAsync()
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = "SELECT * FROM branches";
            var branches = await db.QueryAsync<Branch>(sql);
            return branches.ToList();
        }

        public async Task<Branch?> GetByIdAsync(int id)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = "SELECT * FROM branches WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Branch>(sql, new { Id = id });
        }

        public async Task<Branch> CreateAsync(Branch branch)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = @"
                INSERT INTO branches (location, company_id)
                VALUES (@Location, @CompanyId)
                RETURNING *;";

            var created = await db.QuerySingleAsync<Branch>(sql, branch);
            return created;
        }

        public async Task<bool> UpdateAsync(Branch branch)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = @"
                UPDATE branches
                SET location = @Location,
                    company_id = @CompanyId
                WHERE id = @Id";

            var affected = await db.ExecuteAsync(sql, branch);
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = "DELETE FROM branches WHERE id = @Id";
            var affected = await db.ExecuteAsync(sql, new { Id = id });
            return affected > 0;
        }
    }
}
