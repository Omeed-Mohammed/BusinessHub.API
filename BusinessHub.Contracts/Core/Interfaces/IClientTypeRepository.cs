using BusinessHub.Contracts.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Core.Interfaces
{
    public interface IClientTypeRepository
    {
        List<ClientTypeDto> GetAll(bool? isActive = null);
        ClientTypeDto? GetById(int clientTypeId);

        int Add(ClientTypeDto clientType, string currentUser);
        bool Update(ClientTypeDto clientType, string currentUser);

        bool Deactivate(int clientTypeId);
        bool Reactivate(int clientTypeId);
    }
}
