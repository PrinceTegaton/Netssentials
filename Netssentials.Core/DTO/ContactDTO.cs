using Netssentials.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Netssentials.Core.DTO
{
    public class ContactDTO : BaseModel
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Workplace { get; set; }
        public ContactStatus Status { get; set; }

        public IEnumerable<Address> Addresses { get; set; }


        public static explicit operator ContactDTO(Contact source)
        {
            if (source == null) return null;

            return new ContactDTO
            {
                ID = source.ID,
                Name = source.Name,
                Nickname = source.Nickname,
                MobileNumber = source.MobileNumber,
                EmailAddress = source.EmailAddress,
                Workplace = source.Workplace,
                DateCreated = source.DateCreated,
                DateModified = source.DateModified,
                Status = source.Status,
            };
        }

        public static Expression<Func<Contact, ContactDTO>> List
        {
            get
            {
                return c => new ContactDTO
                {
                    ID = c.ID,
                    Name = c.Name,
                    Nickname = c.Nickname,
                    MobileNumber = c.MobileNumber,
                    EmailAddress = c.EmailAddress,
                    Workplace = c.Workplace,
                    DateCreated = c.DateCreated,
                    DateModified = c.DateModified,
                    Status = c.Status,
                    // Addresses = c.Addresses
                };
            }
        }
    }

    public class CreateContactDTO
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Workplace { get; set; }
        public IEnumerable<AddressDTO> Address { get; set; } = new List<AddressDTO>();

        public Contact ToEntity()
        {
            return new Contact
            {
                Name = this.Name,
                Nickname = this.Nickname,
                MobileNumber = this.MobileNumber,
                EmailAddress = this.EmailAddress,
                Workplace = this.Workplace
            };
        }

        public IEnumerable<Address> GetAddress()
        {
            if (this.Address == null || !this.Address.Any())
                return new List<Address>();

            return this.Address.Select(a => (Address)a).ToList();
        }
    }
}