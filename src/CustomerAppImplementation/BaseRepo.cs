using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAppImplementation
{
    internal abstract class BaseRepo
    {
        protected readonly ICustomerDbContext _customerDbContext;

        public BaseRepo(ICustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
    }
}
