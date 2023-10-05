using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Customers.CreateCustomer
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Address).SetValidator(new CreateCustomerRequestAddressValidator());
        }
    }

    public class CreateCustomerRequestAddressValidator : AbstractValidator<AddressDto>
    {
        public CreateCustomerRequestAddressValidator()
        {
            RuleFor(a => a.Country).NotEmpty();
            RuleFor(a => a.AddressLine1).NotEmpty();
            RuleFor(a => a.City).NotEmpty();
            RuleFor(a => a.PostalCode).NotEmpty();
            RuleFor(a => a.AddressId).NotEmpty().When(a => a.Country == "DK");
            RuleFor(a => a.State).NotEmpty().When(a => a.Country == "US");
            RuleFor(a => a.Region).NotEmpty().When(a => a.Country == "US");
        }
    }
}
