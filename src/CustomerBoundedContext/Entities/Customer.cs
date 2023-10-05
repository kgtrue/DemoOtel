using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBoundedContext.Entities
{
    public class Customer:BaseEntity<Customer, int>
    {
        public Customer() { }

        public Customer(string firstName, string lastName, string email, Address address)
        {           
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public Address Address { get; }
    }
}
