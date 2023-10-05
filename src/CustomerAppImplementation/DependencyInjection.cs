using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerApp.Contracts;

namespace CustomerAppImplementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomerInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ICustomerDbContext, CustomerDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CustomerDatabase"));
            });

            services.AddScoped<ICustomerRepo, CustomerRepo>();
            return services;
        }
    }
}
