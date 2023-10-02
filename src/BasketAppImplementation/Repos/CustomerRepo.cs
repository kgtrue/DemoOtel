using BasketApp.Contracts;
using BasketBoundedContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketAppImplementation.Repos
{
    internal class CustomerRepo : ICustomerRepo
    {
        public Task<Customer> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
