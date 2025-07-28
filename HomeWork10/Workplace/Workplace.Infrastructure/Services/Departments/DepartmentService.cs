using Dapper;
using Npgsql;
using System.Data;
using Workplace.Domain.Models;

namespace Workplace.Infrastructure.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly string _connectionString;

        public DepartmentService()
        {
            _connectionString = "Host=localhost;Port=5432;Database=testcompanydb;Username=postgres;Password=2616";
        }

        public async Task<List<Department>> GetAllAsync()
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = "SELECT * FROM departments";
            var departments = await db.QueryAsync<Department>(sql);
            return departments.ToList();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = "SELECT * FROM departments WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Department>(sql, new { Id = id });
        }

        public async Task<Department> CreateAsync(Department department)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = @"
                INSERT INTO departments (name, company_id)
                VALUES (@Name, @CompanyId)
                RETURNING *;";

            var created = await db.QuerySingleAsync<Department>(sql, department);
            return created;
        }

        public async Task<bool> UpdateAsync(Department department)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = @"
                UPDATE departments
                SET name = @Name,
                    company_id = @CompanyId
                WHERE id = @Id";

            var affected = await db.ExecuteAsync(sql, department);
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = "DELETE FROM departments WHERE id = @Id";
            var affected = await db.ExecuteAsync(sql, new { Id = id });
            return affected > 0;
        }
    }
}
