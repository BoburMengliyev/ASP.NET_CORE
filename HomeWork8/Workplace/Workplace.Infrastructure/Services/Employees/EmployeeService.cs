using Dapper;
using Npgsql;
using System.Data;
using Workplace.Domain.Models;

namespace Workplace.Infrastructure.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly string _connectionString;

        public EmployeeService()
        {
            _connectionString = "Host=localhost;Port=5432;Database=testcompanydb;Username=postgres;Password=2616";
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = "SELECT * FROM employees";
            var employees = await db.QueryAsync<Employee>(sql);
            return employees.ToList();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = "SELECT * FROM employees WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Employee>(sql, new { Id = id });
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = @"
                INSERT INTO employees (first_name, last_name, email, department_id, branch_id)
                VALUES (@FirstName, @LastName, @Email, @DepartmentId, @BranchId)
                RETURNING *;";

            var created = await db.QuerySingleAsync<Employee>(sql, employee);
            return created;
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = @"
                UPDATE employees
                SET first_name = @FirstName,
                    last_name = @LastName,
                    email = @Email,
                    department_id = @DepartmentId,
                    branch_id = @BranchId
                WHERE id = @Id";

            var affected = await db.ExecuteAsync(sql, employee);
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);
            var sql = "DELETE FROM employees WHERE id = @Id";
            var affected = await db.ExecuteAsync(sql, new { Id = id });
            return affected > 0;
        }
    }
}