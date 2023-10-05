using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBoundedContext.Entities
{
    public class Address : BaseEntity<Address, int>
    {
        public Address()
        {

        }
        public Address(string country)
        {
            Country = country;
        }

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
