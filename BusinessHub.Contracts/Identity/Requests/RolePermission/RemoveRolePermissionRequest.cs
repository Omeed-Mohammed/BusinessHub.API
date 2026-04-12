using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Identity.Requests.RolePermission
{
    public class RemoveRolePermissionRequest
    {
        public int RoleID { get; set; }
        public int PermissionID { get; set; }
    }
}
