using BusinessHub.Contracts.Identity.DTOs.UserRole;
using BusinessHub.Contracts.Identity.Interfaces.Roles;
using BusinessHub.Contracts.Identity.Interfaces.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Identity.Services.UserRole
{
    public class UserRoleService
    {
        private readonly IUserRoleRepository _repo;

        public UserRoleService(IUserRoleRepository repo)
        {
            _repo = repo;
        }


        public bool AddUserRole(int userID, int roleID, string currentUser)
        {
            if (userID <= 0)
                throw new ArgumentException("Invalid userID");

            if (roleID <= 0)
                throw new ArgumentException("Invalid roleID");

            return _repo.AddUserRole(userID, roleID, currentUser);
        }

        public bool RemoveUserRole(int userID, int roleID, string currentUser)
        {
            if (userID <= 0)
                throw new ArgumentException("Invalid userID");

            if (roleID <= 0)
                throw new ArgumentException("Invalid roleID");

            return _repo.RemoveUserRole(userID, roleID, currentUser);
        }

        public List<UserRoleUserDto> GetUsersByRoleID(int roleID)
        {
            if (roleID <= 0)
                throw new ArgumentException("Invalid roleID");

            return _repo.GetUsersByRoleID(roleID);
        }

        public List<UserRoleRoleDto> GetRolesByUserID(int userID)
        {
            if (userID <= 0)
                throw new ArgumentException("Invalid userID");

            return _repo.GetRolesByUserID(userID);
        }
    }
}
