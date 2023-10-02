using BasketBoundedContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.Contracts
{
    public interface IBasketRepo
    {
        public Task<Basket> CreateNewBasket(Basket basket);
    }
}
