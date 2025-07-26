using Dapper;
using ExamDapperOrm.Domain.Models;
using Npgsql;
using System.Data;

namespace ExamDapperOrm.Infrastructure.Services
{
    public class PassportRepository : IPassportRepository
    {
        private readonly string _connectionString;

        public PassportRepository()
        {
            _connectionString = "Host=localhost;Port=5432;Database=exam;Username=postgres;Password=2616"; ;
        }

        private IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public async Task<IEnumerable<Passport>> GetAllAsync()
        {
            var sql = "SELECT * FROM passports";
            using var connection = CreateConnection();
            return await connection.QueryAsync<Passport>(sql);
        }

        public async Task<Passport?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM passports WHERE id = @Id";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Passport>(sql, new { Id = id });
        }

        public async Task<bool> CreateAsync(Passport passport)
        {
            var sql = @"INSERT INTO passports (id, serial_number, issue_date, expiry_date)
                        VALUES (@Id, @SerialNumber, @IssueDate, @ExpiryDate)";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, passport);
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Passport passport)
        {
            var sql = @"UPDATE passports
                        SET serial_number = @SerialNumber,
                            issue_date = @IssueDate,
                            expiry_date = @ExpiryDate
                        WHERE id = @Id";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, passport);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM passports WHERE id = @Id";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }
    }
}
