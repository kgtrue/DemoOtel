using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BasketApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBasketApplication(this IServiceCollection services)
        {

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
