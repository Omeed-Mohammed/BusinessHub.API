using BusinessHub.Contracts.Identity.DTOs.Users;
using BusinessHub.Contracts.Identity.Interfaces.UserRole;
using BusinessHub.Contracts.Identity.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Identity.Services.Users
{
    public class UserServices
    {
        private readonly IUserRepository _repo;

        public UserServices(IUserRepository repo)
        {
            _repo = repo;
        }


        public List<UserDto> GetAllUsers(bool? isActive = null)
        {
            return _repo.GetAllUsers(isActive);
        }

        public UserDto GetUserByID(int userID)
        {
            if (userID <= 0)
                throw new ArgumentException("Invalid userID");

            var user = _repo.GetUserByID(userID);

            if (user == null)
                throw new Exception("User not found");

            return user;
        }

        public UserDto GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("username required");

            var user = _repo.GetUserByUsername(username);

            if (user == null)
                throw new Exception("User not found");

            return user;
        }

        public bool DeactivateUser(int userID, string currentUser)
        {
            if (userID <= 0)
                throw new ArgumentException("Invalid userID");

            return _repo.DeactivateUser(userID, currentUser);
        }

        public bool ReactivateUser(int userID, string currentUser)
        {
            if (userID <= 0)
                throw new ArgumentException("Invalid userID");

            return _repo.ReactivateUser(userID, currentUser);
        }

        public int AddUser(CreateUserRequestDto request, string currentUser)
        {
            if (request == null)
                throw new ArgumentException("Invalid data");

            if (string.IsNullOrWhiteSpace(request.Username))
                throw new ArgumentException("Username required");

            // Hash the plain-text password using BCrypt before storing it.
            // BCrypt automatically generates and embeds a salt, making the stored value secure.
            // This ensures we never store raw passwords in the database and can safely verify them later using BCrypt.Verify().

            request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            return _repo.AddUser(request, currentUser);
        }

        public bool ChangePassword(ChangeUserPasswordRequestDto newPass, string currentUser)
        {
            if (newPass.UserID <= 0)
                throw new ArgumentException("Invalid userID");

            if (string.IsNullOrWhiteSpace(newPass.NewPassword))
                throw new ArgumentException("NewPassword required");

            // Hash the plain-text password using BCrypt before storing it.
            // BCrypt automatically generates and embeds a salt, making the stored value secure.
            // This ensures we never store raw passwords in the database and can safely verify them later using BCrypt.Verify().

            newPass.NewPassword = BCrypt.Net.BCrypt.HashPassword(newPass.NewPassword);

            return _repo.ChangePassword(newPass.UserID, newPass.NewPassword, currentUser);
        }
    }
}
