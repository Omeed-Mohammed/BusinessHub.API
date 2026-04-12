using BusinessHub.Contracts.Identity.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Identity.Interfaces.Users
{
    public interface IUserRepository
    {
        List<UserDto> GetAllUsers(bool? isActive = null);
        UserDto? GetUserByID(int userID);
        UserDto? GetUserByUsername(string username);
        bool DeactivateUser(int userID, string currentUser);
        bool ReactivateUser(int userID, string currentUser);
        int AddUser(CreateUserRequestDto request, string currentUser);
        bool ChangePassword(int userID, string passwordHash, string currentUser);
    }
}
