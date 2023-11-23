using CustomerApp.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CustomerAppImplementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomerInfrastructure(this IHostApplicationBuilder builder)
        {
            //builder.AddSqlServerDbContext<CustomerDbContext>(
            //    "CustomerDatabase",
            //    settings =>
            //    {
            //        settings.ConnectionString = builder.Configuration.GetConnectionString("CustomerDatabase");
            //    });

            builder.AddSqlServerDbContext<CustomerDbContext>("CustomerDatabase");

            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
            return builder.Services;
        }
    }
}
