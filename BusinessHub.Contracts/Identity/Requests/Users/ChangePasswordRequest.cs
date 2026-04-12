using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Identity.Requests.Users
{
    public class ChangePasswordRequest
    {
        public int UserID { get; set; }
        public required string NewPassword { get; set; }

    }
}
