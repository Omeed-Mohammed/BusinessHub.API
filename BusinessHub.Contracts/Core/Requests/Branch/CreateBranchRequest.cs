using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Core.Requests.Branch
{
    public class CreateBranchRequest
    {
        public int CompanyID { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
    }
}
