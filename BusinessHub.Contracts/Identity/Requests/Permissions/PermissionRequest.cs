using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Identity.Requests.Permissions
{
    public class PermissionRequest
    {
        public string? PermissionName { get; set; }
        public string? Description { get; set; }
    }
}
