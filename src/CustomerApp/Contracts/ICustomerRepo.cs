using CustomerBoundedContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Contracts
{
    public interface ICustomerRepo
    {
        Task<Customer> CreateCustomer(Customer customer, CancellationToken cancellationToken);
        Task<Customer> GetCustomer(int id, CancellationToken cancellationToken);
    }
}
