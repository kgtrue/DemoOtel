using CustomerApp.Contracts;
using CustomerBoundedContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAppImplementation
{
    internal class CustomerRepo : BaseRepo, ICustomerRepo
    {
        public CustomerRepo(ICustomerDbContext customerDbContext) : base(customerDbContext)
        {

        }

        public async Task<Customer> CreateCustomer(Customer customer, CancellationToken cancellationToken)
        {
            _customerDbContext.Customers.Add(customer);
            await _customerDbContext.SaveChangesAsync(cancellationToken);
            return customer;
        }

        public async Task<Customer> GetCustomer(int id, CancellationToken cancellationToken)
        {
            var customer = await _customerDbContext.Customers.FirstAsync(c=> c.Id == id);
            return customer;
        }
    }
}
