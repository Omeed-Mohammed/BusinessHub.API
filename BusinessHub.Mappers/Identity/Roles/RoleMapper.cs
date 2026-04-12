using BusinessHub.Contracts.Identity.DTOs.Roles;
using BusinessHub.Contracts.Identity.Requests.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Identity.Roles
{
    public class RoleMapper
    {
        public static RoleDto ToDto(RoleRequest r)
        {
            return new RoleDto(
                0,
                r.RoleName,
                r.Description,
                DateTime.Now,
                true,
                null
            );
        }
    }
}
