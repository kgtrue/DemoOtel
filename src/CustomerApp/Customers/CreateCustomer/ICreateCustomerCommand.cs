using CustomerBoundedContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Customers.CreateCustomer
{
    public interface ICreateCustomerCommand
    {
        public Task<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request, CancellationToken cancellationToken);
    }
}
