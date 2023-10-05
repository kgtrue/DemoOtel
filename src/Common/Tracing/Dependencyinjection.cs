using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTelemetry;
using System.Diagnostics;
using OpenTelemetry.Trace;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Common.Tracing.Aspects;

namespace Common.Tracing
{
    public static class Dependencyinjection
    {
        public static IServiceCollection SetupActivitySource(this IServiceCollection services, string serviceName, string version)
        {
            services.AddSingleton<ProxyGenerator>();
            services.TryAddScoped<IInterceptor, DynamicProxyTracingInterceptor>();
            services.AddSingleton((options) => { return new ActivitySource(serviceName, version); });
            services.AddSingleton(TracerProvider.Default.GetTracer(serviceName, version));
            return services;
        }
    }
}
