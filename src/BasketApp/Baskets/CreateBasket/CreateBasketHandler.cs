using BasketApp.Contracts;
using BasketBoundedContext.Entities;
using MediatR;

namespace BasketApp.Baskets.CreateBasket
{
    public class CreateBasketHandler : IRequestHandler<CreateBasketRequest, CreateBasketResponse>
    {
        private readonly IBasketRepo _basketRepo;
        private readonly ICustomerRepo _customerRepo;

        public CreateBasketHandler(IBasketRepo basketRepo, ICustomerRepo customerRepo)
        {
            _basketRepo = basketRepo;
            _customerRepo = customerRepo;
        }

        public async Task<CreateBasketResponse> Handle(CreateBasketRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepo.GetById(request.CustomerId) ?? throw new ArgumentException($"No Customer found for id:{request.CustomerId}");
            var basket = new Basket() { Customer = customer };
            var newBasket = await _basketRepo.CreateNewBasket(basket);

            return new CreateBasketResponse() { BasketId = newBasket.BasketId };
        }
    }
}

