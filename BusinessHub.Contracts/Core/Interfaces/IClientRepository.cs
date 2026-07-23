using BusinessHub.Contracts.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Core.Interfaces
{
    public interface IClientRepository
    {
        List<ClientDto> GetAll(bool? isActive = null);
        List<ClientDto> GetByCompanyId(int companyId);
        ClientDto? GetById(int clientId);

        int Add(ClientDto client, string currentUser);
        bool Update(ClientDto client, string currentUser);

        bool Deactivate(int clientId);
        bool Reactivate(int clientId);
    }
}
