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
        public string? DefaultLanguage { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public CompanySettingsDto(
            int companyID,
            string currencyCode,
            decimal taxRate,
            string? defaultLanguage,
            DateTime createdAt,
            string createdBy,
            DateTime? updatedAt,
            string? updatedBy)
        {
            CompanyID = companyID;
            CurrencyCode = currencyCode;
            TaxRate = taxRate;
            DefaultLanguage = defaultLanguage;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }
    }
}
