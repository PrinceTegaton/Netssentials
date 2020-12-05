using Netssentials.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netssentials.Core.DTO
{
    public class AddressDTO : BaseModel
    {
        public long ContactID { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }


        public static explicit operator AddressDTO(Address source)
        {
            if (source == null) return null;

            return new AddressDTO
            {
                ID = source.ID,
                Description = source.Description,
                City = source.City,
                State = source.State,
                CountryCode = source.CountryCode,
                DateCreated = source.DateCreated,
                DateModified = source.DateModified
            };
        }

        public static explicit operator Address(AddressDTO source)
        {
            if (source == null) return null;

            return new Address
            {
                ID = source.ID,
                Description = source.Description,
                City = source.City,
                State = source.State,
                CountryCode = source.CountryCode,
                DateCreated = source.DateCreated,
                DateModified = source.DateModified
            };
        }
    }
}
