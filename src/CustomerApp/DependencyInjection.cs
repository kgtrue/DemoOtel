using CustomerApp.Customers.CreateCustomer;
using Microsoft.Extensions.DependencyInjection;
using Common.Tracing.Aspects;
namespace CustomerApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomerApplication(this IServiceCollection services)
        {
            services.AddProxiedScoped<ICreateCustomerCommand, CreateCustomerCommand>();
            return services;
        }
    }
}
