using Dapper;
using ExamDapperOrm.Domain.Models;
using Npgsql;
using System.Data;

namespace ExamDapperOrm.Infrastructure.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository()
        {
            _connectionString = "Host=localhost;Port=5432;Database=exam;Username=postgres;Password=2616"; ;
        }

        private IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var sql = "SELECT * FROM students";
            using var connection = CreateConnection();
            return await connection.QueryAsync<Student>(sql);
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM students WHERE id = @Id";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Student>(sql, new { Id = id });
        }

        public async Task<bool> CreateAsync(Student student)
        {
            var sql = @"INSERT INTO students (id, full_name, birth_date, passport_id)
                        VALUES (@Id, @FullName, @BirthDate, @PassportId)";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, student);
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            var sql = @"UPDATE students
                        SET full_name = @FullName,
                            birth_date = @BirthDate,
                            passport_id = @PassportId
                        WHERE id = @Id";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, student);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM students WHERE id = @Id";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }
    }
}
