using BusinessHub.Contracts.Identity.DTOs.RolePermission;
using BusinessHub.Contracts.Identity.Requests.RolePermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Identity.RolePermission
{
    public class RolePermissionMapper
    {
        public static RolePermissionDto ToDto(RolePermissionRequest r)
        {
            return new RolePermissionDto(
                r.RoleID,
                r.PermissionID
            );
        }
    }
}
