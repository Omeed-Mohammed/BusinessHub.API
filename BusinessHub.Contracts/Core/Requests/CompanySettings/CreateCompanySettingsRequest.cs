using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Core.Requests.CompanySettings
{
    public class CreateCompanySettingsRequest
    {
        public int CompanyID { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public decimal TaxRate { get; set; }
        public string? DefaultLanguage { get; set; }
    }
}
