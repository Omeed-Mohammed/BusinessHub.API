using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Core.Services
{
    public class ClientService
    {
        private readonly IClientRepository _repo;

        public ClientService(IClientRepository repo)
        {
            _repo = repo;
        }

        public List<ClientDto> GetAll(bool? isActive = null)
        {
            return _repo.GetAll(isActive) ?? new List<ClientDto>();
        }

        public int Add(ClientDto client, string currentUser)
        {
            if (client == null)
                throw new ArgumentException("Invalid data");

            return _repo.Add(client, currentUser);
        }

        public bool Update(ClientDto client, string currentUser)
        {
            if (client == null || client.ClientID <= 0)
                throw new ArgumentException("Invalid data");

            return _repo.Update(client, currentUser);
        }

        public List<ClientDto> GetByCompanyId(int companyId)
        {
            if (companyId <= 0)
                throw new ArgumentException("Invalid CompanyID");

            return _repo.GetByCompanyId(companyId) ?? new List<ClientDto>();
        }

        public ClientDto GetById(int clientId)
        {
            if (clientId <= 0)
                throw new ArgumentException("Invalid ClientID");

            var client = _repo.GetById(clientId);

            if (client == null)
                throw new KeyNotFoundException("Client not found");

            return client;
        }

        public bool Deactivate(int clientId)
        {
            if (clientId <= 0)
                throw new ArgumentException("Invalid ClientID");

            return _repo.Deactivate(clientId);
        }

        public bool Reactivate(int clientId)
        {
            if (clientId <= 0)
                throw new ArgumentException("Invalid ClientID");

            return _repo.Reactivate(clientId);
        }
    }
}
