using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.Baskets.CreateBasket
{
    public class CreateBasketRequest: IRequest<CreateBasketResponse>
    {
        public Guid CustomerId { get; set; }
    }
}
