using BusinessHub.Contracts.Identity.DTOs.UserRole;
using BusinessHub.Contracts.Identity.Requests.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Identity.UserRole
{
    public static class UserRoleMapper
    {
        public static UserRoleDto ToDto(UserRoleRequest request)
        {
            return new UserRoleDto(
                request.UserID,
                request.RoleID
            );
        }
    }
}
