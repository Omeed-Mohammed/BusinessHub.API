using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Requests.ClientTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Core.ClientTypes
{
    public class CreateClientTypeMapper
    {
        public static ClientTypeDto ToDto(CreateClientTypeRequest request, string currentUser)
        {
            return new ClientTypeDto(
                0,
                request.ClientTypeName,
                true,
                DateTime.UtcNow,
                currentUser,
                null,
                null
            );
        }
    }
}
