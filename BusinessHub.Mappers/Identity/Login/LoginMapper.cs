using BusinessHub.Contracts.Identity.DTOs.Login;
using BusinessHub.Contracts.Identity.Requests.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Identity.Login
{
    public class LoginMapper
    {
        public static LoginRequestDto ToDto(LoginRequest r)
        {
            return new LoginRequestDto(
                r.Username,
                r.Password
            );
        }
    }
}
