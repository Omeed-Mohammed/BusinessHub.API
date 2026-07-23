using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Core.Requests.Client
{
    public class CreateClientRequest
    {
        public int CompanyID { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Note { get; set; }
        public int? ClientTypeID { get; set; }
    }
}
