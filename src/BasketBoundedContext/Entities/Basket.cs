using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBoundedContext.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public Guid BasketId { get; set; }
        public Customer Customer { get; set; }

    }
}
