using ExamDapperOrm.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDapperOrm.Infrastructure.Services
{
    public interface IPassportRepository
    {
        Task<IEnumerable<Passport>> GetAllAsync();
        Task<Passport?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Passport passport);
        Task<bool> UpdateAsync(Passport passport);
        Task<bool> DeleteAsync(int id);
    }
}
