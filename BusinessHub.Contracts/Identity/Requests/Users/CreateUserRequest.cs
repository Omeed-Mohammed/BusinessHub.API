using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Identity.Requests.Users
{
    public class CreateUserRequest
    {
        public int PersonID { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
