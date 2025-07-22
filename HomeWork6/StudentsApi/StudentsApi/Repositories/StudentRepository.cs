using Dapper;
using StudentsApi.Data;
using StudentsApi.Models;

namespace StudentsApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DapperContext _context;

        public StudentRepository(DapperContext context) => _context = context;

        public async Task<IEnumerable<Student>> GetAllAsync() 
        {
            var query = "SELECT * FROM students";

            using (var connection = _context.CreateConnection()) 
            {
                var student = await connection.QueryAsync<Student>(query);
                return student.ToList();
            }
        }

        public async Task<Student?> GetByIdAsync(int id) 
        {
            var query = "SELECT * FROM students WHERE id = @Id";

            using (var connection = _context.CreateConnection()) 
            {
                return await connection.QuerySingleOrDefaultAsync<Student>(query, new { Id = id});
            }
        }

        public async Task<int> CreateAsync(Student student) 
        {
            var query = @" INSERT INTO students (name, lastname, age, ""student_group"", phone_number, email, gender, is_active, created_date)
            VALUES (@Name, @LastName, @Age, @StudentGroup, @PhoneNumber, @Email, @Gender, @IsActive, @CreatedDate)
            RETURNING id;";

            using (var connection = _context.CreateConnection()) 
            {
                var id = await connection.ExecuteScalarAsync<int>(query, student);
                return id;
            }
        }

        public async Task<bool> UpdateAsync(Student student) 
        {
            var query = @"UPDATE students SET
            name = @Name,
            lastname = @LastName,
            age = @Age,
            ""student_group"" = @StudentGroup,
            phone_number = @PhoneNumber,
            email = @Email,
            gender = @Gender,
            is_active = @IsActive
            WHERE id = @Id";

            using (var connection = _context.CreateConnection()) 
            {
                var rowsAffected = await connection.ExecuteAsync(query, student);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id) 
        {
            var query = "DELETE FROM students WHERE id = @Id";

            using (var connection = _context.CreateConnection()) 
            {
                var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
                return rowsAffected > 0;
            }
        }
    }
}
