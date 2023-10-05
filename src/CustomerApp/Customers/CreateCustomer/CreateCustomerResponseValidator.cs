using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Customers.CreateCustomer
{
    public class CreateCustomerResponseValidator:AbstractValidator<CreateCustomerResponse>
    {
        public CreateCustomerResponseValidator()
        {
            RuleFor(x=> x.CustomerId).NotEmpty();
        }
    }
}
