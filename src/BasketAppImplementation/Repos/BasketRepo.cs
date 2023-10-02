using BasketApp.Contracts;
using BasketBoundedContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketAppImplementation.Repos
{
    internal class BasketRepo : IBasketRepo
    {
        public Task<Basket> CreateNewBasket(Basket basket)
        {
            throw new NotImplementedException();
        }
    }
}
