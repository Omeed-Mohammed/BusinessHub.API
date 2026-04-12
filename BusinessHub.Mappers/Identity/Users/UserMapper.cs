using BusinessHub.Contracts.Identity.DTOs.Users;
using BusinessHub.Contracts.Identity.Requests.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Identity.Users
{
    public class UserMapper
    {
        public static CreateUserRequestDto ToDto(CreateUserRequest r, string currentUser)
        {
            return new CreateUserRequestDto(
                r.PersonID,
                r.Username,
                r.Password,
                currentUser
            );
        }

        public static ChangeUserPasswordRequestDto ToDto(ChangePasswordRequest r)
        {
            return new ChangeUserPasswordRequestDto(
                r.UserID,
                r.NewPassword
            );
        }
    }
}
