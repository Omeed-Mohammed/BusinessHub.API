using BusinessHub.Contracts.Identity.DTOs.RolePermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Identity.Interfaces.RolePermission
{
    public interface IRolePermissionRepository
    {
        int AddRolePermission(RolePermissionDto RolePermission, string currentUser);
        List<PermissionSummaryDto> GetPermissionsByRoleID(int roleID);
        List<RoleSummaryDto> GetRolesByPermissionID(int permissionID);
        bool RemoveRolePermission(int roleID, int permissionID, string currentUser);
    }
}
