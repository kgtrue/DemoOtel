using CustomerBoundedContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAppImplementation.Mappings
{
    internal class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(200).IsRequired();
            builder.HasOne(e => e.Address).WithOne().HasForeignKey<Customer>("AddressId").IsRequired();
        }
    }
}
