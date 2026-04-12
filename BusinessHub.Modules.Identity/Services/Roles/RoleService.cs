using BusinessHub.Contracts.Identity.DTOs.Roles;
using BusinessHub.Contracts.Identity.Interfaces.RolePermission;
using BusinessHub.Contracts.Identity.Interfaces.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Identity.Services.Roles
{
    public class RoleService
    {
        private readonly IRoleRepository _repo;

        public RoleService(IRoleRepository repo)
        {
            _repo = repo;
        }



        public int AddRole(RoleDto role, string currentUser)
        {
            if (role == null)
                throw new ArgumentException("Invalid data");

            if (string.IsNullOrWhiteSpace(role.RoleName))
                throw new ArgumentException("RoleName required");

            return _repo.AddRole(role, currentUser);
        }

        public bool UpdateRole(RoleDto role, string currentUser)
        {
            if (role == null || role.RoleID <= 0)
                throw new ArgumentException("Invalid data");

            if (string.IsNullOrWhiteSpace(role.RoleName))
                throw new ArgumentException("RoleName required");

            return _repo.UpdateRole(role, currentUser);
        }

        public List<RoleDto> GetAllRoles()
        {
            return _repo.GetAllRoles();
        }

        public RoleDto GetRoleByID(int roleID)
        {
            if (roleID <= 0)
                throw new ArgumentException("Invalid roleID");

            var role = _repo.GetRoleByID(roleID);

            if (role == null)
                throw new Exception("Role not found");

            return role;
        }

        public bool DeactivateRole(int roleID, string currentUser)
        {
            if (roleID <= 0)
                throw new ArgumentException("Invalid roleID");

            return _repo.DeactivateRole(roleID, currentUser);
        }

        public bool ReactivateRole(int roleID, string currentUser)
        {
            if (roleID <= 0)
                throw new ArgumentException("Invalid roleID");

            return _repo.ReactivateRole(roleID, currentUser);
        }
    }
}
