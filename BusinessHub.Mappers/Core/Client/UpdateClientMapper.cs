using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Requests.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Core.Client
{
    public class UpdateClientMapper
    {
        public static ClientDto ToDto(UpdateClientRequest request, string currentUser)
        {
            return new ClientDto(
                request.ClientID,
                request.CompanyID,
                request.ClientName,
                request.Phone,
                request.Email,
                request.Address,
                request.Note,
                true,
                DateTime.UtcNow,   // ignored
                currentUser,
                DateTime.UtcNow,
                currentUser,
                request.ClientTypeID
            );
        }
    }
}
