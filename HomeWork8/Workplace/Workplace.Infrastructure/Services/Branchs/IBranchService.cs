using Workplace.Domain.Models;

namespace Workplace.Infrastructure.Services.Branchs
{
    public interface IBranchService
    {
        Task<List<Branch>> GetAllAsync();
        Task<Branch?> GetByIdAsync(int id);
        Task<Branch> CreateAsync(Branch branch);
        Task<bool> UpdateAsync(Branch branch);
        Task<bool> DeleteAsync(int id);
    }
}
