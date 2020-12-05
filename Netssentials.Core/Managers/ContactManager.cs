using Microsoft.Extensions.Logging;
using Netssentials.Core.DTO;
using Netssentials.Core.Models;
using Netssentials.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netssentials.Core.Managers
{
    public class ContactManager : ManagerBase<Contact>, IContactManager
    {
        private readonly ISimpleRepository<Contact> _contactEntity;
        private readonly ISimpleRepository<Address> _addressEntity;

        public ContactManager(ILogger<Contact> logger,
                                ISimpleRepository<Contact> contactEntity,
                                ISimpleRepository<Address> addressEntity) : base(logger)
        {
            _contactEntity = contactEntity;
            _addressEntity = addressEntity;
        }

        public async Task<Guid> Create(CreateContactDTO contact)
        {
            Contact entity = contact.ToEntity();
            bool res = await _contactEntity.AddAsync(entity);

            if(contact.Address.Any())
            {
                res = await _addressEntity.AddRangeAsync(contact.GetAddress());
            }

            return entity.ID;
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactDTO>> GetAllContacts(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ContactDTO> GetContactById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
