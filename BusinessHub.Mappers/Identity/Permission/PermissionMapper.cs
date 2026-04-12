using BusinessHub.Contracts.Identity.DTOs.Permissions;
using BusinessHub.Contracts.Identity.Requests.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Identity.Permission
{
    public class PermissionMapper
    {
        public static PermissionDto ToDto(PermissionRequest r)
        {
            return new PermissionDto(
                0,
                r.PermissionName!,
                r.Description,
                null!,
                DateTime.Now,
                true
            );
        }
    }
}
