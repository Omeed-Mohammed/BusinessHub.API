using BusinessHub.Contracts.Identity.DTOs.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Identity.Interfaces.Login
{
    public interface ILoginRepository
    {
        UserAuthDto GetUserByInfoUsername(string username);
    }
}
