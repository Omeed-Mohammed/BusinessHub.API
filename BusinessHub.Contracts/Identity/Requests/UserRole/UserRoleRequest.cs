using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Identity.Requests.UserRole
{
    public class UserRoleRequest
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
    }
}
