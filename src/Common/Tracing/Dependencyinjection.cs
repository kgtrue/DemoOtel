using Microsoft.Extensions.DependencyInjection;

namespace Common.Tracing
{
    public static class Dependencyinjection
    {
        public static IServiceCollection SetupActivitySource(this IServiceCollection services, string serviceName, string version)
        {
        
            return services;
        }
    }
}
