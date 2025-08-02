using BankExamAPI.Models;

namespace BankExamAPI.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account?> GetByIdAsync(int id);
        Task<Account> CreateAsync(Account account);
        Task<Account?> UpdateAsync(int id, Account account);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Account>> GetByCustomerIdAsync(int customerId);
    }
}
