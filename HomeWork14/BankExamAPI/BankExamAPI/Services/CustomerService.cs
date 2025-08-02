using BankExamAPI.Models;
using BankExamAPI.Services.Interfaces;

namespace BankExamAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = new();
        private int _nextId = 1;

        public Task<IEnumerable<Customer>> GetAllAsync() => Task.FromResult(_customers.AsEnumerable());

        public Task<Customer?> GetByIdAsync(int id) =>
            Task.FromResult(_customers.FirstOrDefault(c => c.Id == id));

        public Task<Customer> CreateAsync(Customer customer)
        {
            customer.Id = _nextId++;
            _customers.Add(customer);
            return Task.FromResult(customer);
        }

        public Task<Customer?> UpdateAsync(int id, Customer updated)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer == null) return Task.FromResult<Customer?>(null);

            customer.FullName = updated.FullName;
            customer.Email = updated.Email;
            customer.PhoneNumber = updated.PhoneNumber;
            customer.Address = updated.Address;
            return Task.FromResult<Customer?>(customer);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer == null) return Task.FromResult(false);
            _customers.Remove(customer);
            return Task.FromResult(true);
        }
    }

}
