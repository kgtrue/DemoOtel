using BasketApp.Contracts;
using BasketAppImplementation.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace BasketAppImplementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBasketInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBasketRepo, BasketRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            return services;
        }
    }
}
