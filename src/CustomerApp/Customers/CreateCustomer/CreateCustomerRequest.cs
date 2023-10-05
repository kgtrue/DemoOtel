using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Customers.CreateCustomer
{
    public class CreateCustomerRequest
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public AddressDto Address { get; }
    }

    public class AddressDto
    {
        public string Country { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public string State { get; set; }
        public string AddressId { get; set; }
    }
}
