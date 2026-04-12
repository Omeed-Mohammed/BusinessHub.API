using BusinessHub.Contracts.Identity.DTOs.Permissions;
using BusinessHub.Contracts.Identity.Interfaces.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Identity.Services.Permissions
{
    public class PermissionService
    {
        private readonly IPermissionRepository _repo;

        public PermissionService(IPermissionRepository repo)
        {
            _repo = repo;
        }

        public int AddPermission(PermissionDto permission, string currentUser)
        {
            if (permission == null)
                throw new ArgumentException("Invalid data");

            if (string.IsNullOrWhiteSpace(permission.PermissionName))
                throw new ArgumentException("PermissionName required");

            return _repo.AddPermission(permission, currentUser);
        }

        public bool UpdatePermission(PermissionDto permission, string currentUser)
        {
            if (permission == null || permission.PermissionID <= 0)
                throw new ArgumentException("Invalid data");

            if (string.IsNullOrWhiteSpace(permission.PermissionName))
                throw new ArgumentException("PermissionName required");

            return _repo.UpdatePermission(permission, currentUser);
        }

        public List<PermissionDto> GetAllPermissions()
        {
            return _repo.GetAllPermissions();
        }

        public PermissionDto GetPermissionByID(int permissionID)
        {
            if (permissionID <= 0)
                throw new ArgumentException("Invalid permissionID");

            return _repo.GetPermissionByID(permissionID);
        }

        public bool DeactivatePermission(int permissionID, string currentUser)
        {
            if (permissionID <= 0)
                throw new ArgumentException("Invalid permissionID");

            return _repo.DeactivatePermission(permissionID, currentUser);
        }

        public bool ReactivatePermission(int permissionID, string currentUser)
        {
            if (permissionID <= 0)
                throw new ArgumentException("Invalid permissionID");

            return _repo.ReactivatePermission(permissionID, currentUser);
        }
    }
}
