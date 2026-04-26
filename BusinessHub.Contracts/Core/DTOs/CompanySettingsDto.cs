using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Core.DTOs
{
    public class CompanySettingsDto
    {
        public int CompanyID { get; set; }
        public string CurrencyCode { get; set; }
        public decimal TaxRate { get; set; }
        public string? LogoPath { get; set; }
        public string? DefaultLanguage { get; set; }
        public DateTime CreatedAt { get; set; }

        public CompanySettingsDto(
            int companyID,
            string currencyCode,
            decimal taxRate,
            string? logoPath,
            string? defaultLanguage,
            DateTime createdAt)
        {
            CompanyID = companyID;
            CurrencyCode = currencyCode;
            TaxRate = taxRate;
            LogoPath = logoPath;
            DefaultLanguage = defaultLanguage;
            CreatedAt = createdAt;
        }
    }
}
