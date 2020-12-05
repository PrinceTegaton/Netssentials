using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netssentials.Core.Models
{
    public class Contact : BaseModel
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Workplace { get; set; }
        public ContactStatus Status { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }

    public enum ContactStatus
    {
        Active = 1,
        Inactive = 2
    }

    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Nickname).HasMaxLength(50);
            builder.Property(e => e.MobileNumber).HasMaxLength(20);
            builder.Property(e => e.EmailAddress).HasMaxLength(50);
            builder.Property(e => e.Workplace).HasMaxLength(50);
            builder.Property(e => e.Status).IsRequired().HasDefaultValue(ContactStatus.Active);

            Guid c1 = Guid.NewGuid();
            Guid c2 = Guid.NewGuid();

            var data = new List<Contact>
            {
                new Contact
                {
                    ID = c1,
                    Name = "Jamie Lanister",
                    Nickname = "The King Slayer",
                    MobileNumber = "+447787867821",
                    EmailAddress = "jamie.lanister@got.org",
                    Workplace = "GOT Actor",
                    Status = ContactStatus.Active
                },
                new Contact
                {
                    ID = c2,
                    Name = "Mason Greedwood",
                    Nickname = "Gunwood",
                    MobileNumber = "+447719867821",
                    EmailAddress = "mason.greenwood@manutd.com",
                    Workplace = "MUFC Football Player",
                    Status = ContactStatus.Active
                }
            };

            builder.HasData(data.ToArray());
        }
    }
}
