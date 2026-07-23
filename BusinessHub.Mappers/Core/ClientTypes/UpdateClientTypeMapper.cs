using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Requests.ClientTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Core.ClientTypes
{
    public class UpdateClientTypeMapper
    {
        public static ClientTypeDto ToDto(UpdateClientTypeRequest request, string currentUser)
        {
            return new ClientTypeDto(
                request.ClientTypeID,
                request.ClientTypeName,
                true,
                DateTime.UtcNow,
                currentUser,
                DateTime.UtcNow,
                currentUser
            );
        }
    }
}
