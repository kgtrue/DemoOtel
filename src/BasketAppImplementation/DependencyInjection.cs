using BasketApp.Contracts;
using BasketAppImplementation.Repos;
using Microsoft.Extensions.DependencyInjection;
using Common.Tracing.Aspects;

namespace BasketAppImplementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBasketInfrastructure(this IServiceCollection services)
        {
            services.AddProxiedScoped<IBasketRepo, BasketRepo>();
            services.AddProxiedScoped<ICustomerRepo, CustomerRepo>();
            return services;
        }
    }
}
