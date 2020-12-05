using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netssentials.Core.Models
{
    public class Address : BaseModel
    {
        public long ContactID { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }

        public virtual Contact Contact { get; set; }
    }

    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(e => e.ContactID).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(50).IsRequired();
            builder.Property(e => e.City).HasMaxLength(50);
            builder.Property(e => e.State).HasMaxLength(50);
            builder.Property(e => e.CountryCode).HasMaxLength(2);
        }
    }
}
