using ExamDapperOrm.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDapperOrm.Infrastructure.Services
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Student student);
        Task<bool> UpdateAsync(Student student);
        Task<bool> DeleteAsync(int id);
    }
}
