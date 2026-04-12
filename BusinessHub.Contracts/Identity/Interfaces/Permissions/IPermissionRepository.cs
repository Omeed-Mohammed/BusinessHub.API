using BusinessHub.Contracts.Identity.DTOs.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Identity.Interfaces.Permissions
{
    public interface IPermissionRepository
    {
        int AddPermission(PermissionDto permission, string currentUser);
        bool UpdatePermission(PermissionDto permission, string currentUser);
        List<PermissionDto> GetAllPermissions();
        PermissionDto GetPermissionByID(int permissionID);
        bool DeactivatePermission(int permissionID, string currentUser);
        bool ReactivatePermission(int permissionID, string currentUser);
    }
}
