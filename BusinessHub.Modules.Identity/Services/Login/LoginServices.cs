using BusinessHub.Contracts.Identity.DTOs.Login;
using BusinessHub.Contracts.Identity.Interfaces.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;


namespace BusinessHub.Modules.Identity.Services.Login
{
    public class LoginServices
    {
        private readonly ILoginRepository _repo;

        public LoginServices(ILoginRepository repo)
        {
            _repo = repo;
        }

        public bool LoginRequest(LoginRequestDto request , string CurrentUser)
        {
            // Step 1: Check if a User with the provided Username exists in the database.
            // The Username is used as the unique login identifier.
            UserAuthDto userAuth = _repo.GetUserByInfoUsername(request.Username);


            // If no User is found with the given email,
            // return 401 Unauthorized without revealing which field was wrong.
            if (userAuth == null)
                return false;


            if (!userAuth.IsActive)
            {
                return false;
            }

            // Step 2: Verify the provided password against the stored password hash.
            // BCrypt handles hashing and salt internally.
            // If the password does not match, return 401 Unauthorized.

            bool isValidPassword =
               BCrypt.Net.BCrypt.Verify(request.Password, userAuth.PasswordHash);

            // If the password does not match the stored hash,
            // return 401 Unauthorized.
            if (!isValidPassword)
                return false;


            CurrentUser = request.Username;

            return true;

        }
    }
}
