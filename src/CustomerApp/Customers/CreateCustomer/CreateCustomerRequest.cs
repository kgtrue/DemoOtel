using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerApp.Customers.CreateCustomer
{
    public class CreateCustomerRequest
    {
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("address")]
        public AddressDto Address { get; set; }
    }

    public class AddressDto
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("addressline1")]
        public string AddressLine1 { get; set; }

        [JsonPropertyName("addressline2")]
        public string AddressLine2 { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("postalcode")]
        public string PostalCode { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("addressid")]
        public string AddressId { get; set; }
    }
}
