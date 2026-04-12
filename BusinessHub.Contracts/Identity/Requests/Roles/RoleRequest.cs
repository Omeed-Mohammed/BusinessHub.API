using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Identity.Requests.Roles
{
    public class RoleRequest
    {
        public string RoleName { get; set; }
        public string? Description { get; set; }
    }
}
