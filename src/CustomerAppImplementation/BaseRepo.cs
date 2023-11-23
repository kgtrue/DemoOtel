using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAppImplementation
{
    internal abstract class BaseRepo
    {
        protected readonly CustomerDbContext _customerDbContext;

        public BaseRepo(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
    }
}
