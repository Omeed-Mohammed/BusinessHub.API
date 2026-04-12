using BusinessHub.Contracts.Identity.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Identity.Interfaces.Roles
{
    public interface IRoleRepository
    {
        int AddRole(RoleDto role, string currentUser);
        bool UpdateRole(RoleDto role, string currentUser);
        List<RoleDto> GetAllRoles();
        RoleDto? GetRoleByID(int roleID);
        bool DeactivateRole(int roleID, string currentUser);
        bool ReactivateRole(int roleID, string currentUser);
    }
}
