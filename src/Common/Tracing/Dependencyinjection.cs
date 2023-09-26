using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTelemetry;
using System.Diagnostics;

namespace Common.Tracing
{
    public static class Dependencyinjection
    {
        public static IServiceCollection SetupActivitySource(this IServiceCollection services, string serviceName, string version)
        {
            services.AddSingleton((options) => { return new ActivitySource(serviceName, version); });
            return services;
        }
    }
}
