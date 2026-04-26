using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Requests.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Core.Client
{
    public class CreateClientMapper
    {
        public static ClientDto ToDto(CreateClientRequest request, string currentUser)
        {
            return new ClientDto(
                0,
                request.CompanyID,
                request.ClientName,
                request.Phone,
                request.Email,
                request.Address,
                request.Note,
                true,
                DateTime.UtcNow,
                currentUser,
                null,
                null
            );
        }
    }
}
