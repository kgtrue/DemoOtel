using CustomerApp.Customers.CreateCustomer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomerApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateCustomerCommand, CreateCustomerCommand>();
            return services;
        }
    }
}
