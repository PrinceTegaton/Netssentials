using Netssentials.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Netssentials.Core.Managers
{
    public interface IContactManager
    {
        Task<Guid> Create(CreateContactDTO contact);
        Task<ContactDTO> GetContactById(Guid id);
        Task<IEnumerable<ContactDTO>> GetAllContacts(Guid id);
        Task<bool> Delete(Guid id);
    }
}
