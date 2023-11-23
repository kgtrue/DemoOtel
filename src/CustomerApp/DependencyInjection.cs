using Microsoft.Extensions.DependencyInjection;
namespace CustomerApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomerApplication(this IServiceCollection services)
        {
          
            return services;
        }
    }
}
