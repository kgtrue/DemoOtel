using CustomerBoundedContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAppImplementation.Mappings
{
    internal class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Country).HasMaxLength(200).IsRequired();
            builder.Property(e => e.AddressLine1).HasMaxLength(200).IsRequired();
            builder.Property(e => e.AddressLine2).HasMaxLength(200);
            builder.Property(e => e.City).HasMaxLength(200).IsRequired();
            builder.Property(e => e.PostalCode).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Region).HasMaxLength(200);
            builder.Property(e => e.State).HasMaxLength(200);
            builder.Property(e => e.AddressId).HasMaxLength(100);
        }
    }
}
