using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Core.Requests.Company
{
    public class CreateCompanyRequest
    {
        public string CompanyName { get; set; } = string.Empty;
        public string? BusinessType { get; set; }
        public string? LicenseNumber { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? AddressLine { get; set; }
        public string? LogoPath { get; set; }
    }
}
