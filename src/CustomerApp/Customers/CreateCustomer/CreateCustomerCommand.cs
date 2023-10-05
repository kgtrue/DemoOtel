using CustomerApp.Contracts;
using CustomerBoundedContext.Entities;
using FluentValidation;

namespace CustomerApp.Customers.CreateCustomer
{
    public class CreateCustomerCommand : ICreateCustomerCommand
    {
        private readonly ICustomerRepo _customerRepo;

        public CreateCustomerCommand(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public async Task<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            //Request ACL
            var requestValidator = new CreateCustomerRequestValidator();
            requestValidator.Validate(request, options => options.ThrowOnFailures());

            var customer = await _customerRepo.CreateCustomer(
                new Customer(
                    request.FirstName,
                    request.LastName,
                    request.Email,
                    new Address(request.Address.Country) { 
                        AddressLine1 = request.Address.AddressLine1, 
                        AddressLine2 = request.Address.AddressLine2, 
                        City = request.Address.City, 
                        PostalCode = request.Address.PostalCode, 
                        State = request.Address.State, 
                        Region = request.Address.Region, 
                        AddressId = request.Address.AddressId }),
                cancellationToken);

            var response = new CreateCustomerResponse()
            {
                CustomerId = customer.Id.ToString()
            };

            //Response ACL
            var responseValidator = new CreateCustomerResponseValidator();
            responseValidator.Validate(response, options => options.ThrowOnFailures());

            return response;
        }
    }
}
