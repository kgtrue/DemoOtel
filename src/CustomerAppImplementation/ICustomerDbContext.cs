using CustomerBoundedContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CustomerAppImplementation
{
    public interface ICustomerDbContext
    {
        public void Migrate();

        public DbSet<Customer> Customers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
