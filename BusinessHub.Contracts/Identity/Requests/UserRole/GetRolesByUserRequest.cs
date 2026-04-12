using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Identity.Requests.UserRole
{
    public class GetRolesByUserRequest
    {
        public int UserID { get; set; }
    }
}
