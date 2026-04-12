using BusinessHub.Contracts.Identity.DTOs.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Identity.Interfaces.UserRole
{
    public interface IUserRoleRepository
    {
        bool AddUserRole(int userID, int roleID, string currentUser);
        bool RemoveUserRole(int userID, int roleID, string currentUser);
        List<UserRoleUserDto> GetUsersByRoleID(int roleID);
        List<UserRoleRoleDto> GetRolesByUserID(int userID);
    }
}
