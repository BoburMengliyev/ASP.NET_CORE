using BankExamAPI.Models;
using BankExamAPI.Services.Interfaces;

namespace BankExamAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly List<Account> _accounts = new();
        private int _nextId = 1;

        public Task<IEnumerable<Account>> GetAllAsync() => Task.FromResult(_accounts.AsEnumerable());

        public Task<Account?> GetByIdAsync(int id) =>
            Task.FromResult(_accounts.FirstOrDefault(a => a.Id == id));

        public Task<Account> CreateAsync(Account account)
        {
            account.Id = _nextId++;
            _accounts.Add(account);
            return Task.FromResult(account);
        }

        public Task<Account?> UpdateAsync(int id, Account updated)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == id);
            if (account == null) return Task.FromResult<Account?>(null);

            account.AccountNumber = updated.AccountNumber;
            account.AccountType = updated.AccountType;
            account.Balance = updated.Balance;
            account.CustomerId = updated.CustomerId;

            return Task.FromResult(account);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == id);
            if (account == null) return Task.FromResult(false);
            _accounts.Remove(account);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Account>> GetByCustomerIdAsync(int customerId)
        {
            var result = _accounts.Where(a => a.CustomerId == customerId);
            return Task.FromResult(result.AsEnumerable());
        }
    }

}
