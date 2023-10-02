using BasketBoundedContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.Contracts
{
    public interface ICustomerRepo
    {
        public Task<Customer> GetById(Guid id);
    }
}
