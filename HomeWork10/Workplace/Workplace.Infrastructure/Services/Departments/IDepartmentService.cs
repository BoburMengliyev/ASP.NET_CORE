using Workplace.Domain.Models;

namespace Workplace.Infrastructure.Services.Departments
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task<Department> CreateAsync(Department department);
        Task<bool> UpdateAsync(Department department);
        Task<bool> DeleteAsync(int id);
    }
}
