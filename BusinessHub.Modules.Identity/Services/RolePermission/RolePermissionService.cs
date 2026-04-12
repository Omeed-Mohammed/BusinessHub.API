using BusinessHub.Contracts.Identity.DTOs.RolePermission;
using BusinessHub.Contracts.Identity.Interfaces.Permissions;
using BusinessHub.Contracts.Identity.Interfaces.RolePermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Identity.Services.RolePermission
{
    public class RolePermissionService 
    {
        private readonly IRolePermissionRepository _repo;

        public RolePermissionService(IRolePermissionRepository repo)
        {
            _repo = repo;
        }

        public int AddRolePermission(RolePermissionDto RolePermission, string currentUser)
        {
            if (RolePermission == null)
                throw new ArgumentException("Invalid data");

            return _repo.AddRolePermission(RolePermission, currentUser);
        }

        public List<PermissionSummaryDto> GetPermissionsByRoleID(int roleID)
        {
            if (roleID <= 0)
                throw new ArgumentException("Invalid roleID");

            return _repo.GetPermissionsByRoleID(roleID);
        }

        public List<RoleSummaryDto> GetRolesByPermissionID(int permissionID)
        {
            if (permissionID <= 0)
                throw new ArgumentException("Invalid permissionID");

            return _repo.GetRolesByPermissionID(permissionID);
        }

        public bool RemoveRolePermission(int roleID, int permissionID, string currentUser)
        {
            if (roleID <= 0)
                throw new ArgumentException("Invalid roleID");

            if (permissionID <= 0)
                throw new ArgumentException("Invalid permissionID");

            return _repo.RemoveRolePermission(roleID, permissionID, currentUser);
        }
    }
}
