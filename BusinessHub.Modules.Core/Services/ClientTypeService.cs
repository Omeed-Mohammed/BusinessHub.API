using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Core.Services
{
    public class ClientTypeService
    {
        private readonly IClientTypeRepository _repo;

        public ClientTypeService(IClientTypeRepository repo)
        {
            _repo = repo;
        }

        public int Add(ClientTypeDto clientType, string currentUser)
        {
            if (clientType == null)
                throw new ArgumentNullException(nameof(clientType));

            return _repo.Add(clientType, currentUser);
        }

        public bool Update(ClientTypeDto clientType, string currentUser)
        {
            if (clientType == null || clientType.ClientTypeID <= 0)
                throw new ArgumentException("Invalid data");

            return _repo.Update(clientType, currentUser);
        }

        public List<ClientTypeDto> GetAll(bool? isActive = null)
        {
            return _repo.GetAll(isActive) ?? new List<ClientTypeDto>();
        }

        public ClientTypeDto GetById(int clientTypeId)
        {
            if (clientTypeId <= 0)
                throw new ArgumentException("Invalid ClientTypeID");

            var clientType = _repo.GetById(clientTypeId);

            if (clientType == null)
                throw new KeyNotFoundException("ClientType not found");

            return clientType;
        }

        public bool Deactivate(int clientTypeId)
        {
            if (clientTypeId <= 0)
                throw new ArgumentException("Invalid ClientTypeID");

            return _repo.Deactivate(clientTypeId);
        }

        public bool Reactivate(int clientTypeId)
        {
            if (clientTypeId <= 0)
                throw new ArgumentException("Invalid ClientTypeID");

            return _repo.Reactivate(clientTypeId);
        }
    }
}
