using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Requests.CompanySettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Core.CompanySettings
{
    public class CreateCompanySettingsMapper
    {
        public static CompanySettingsDto ToDto(CreateCompanySettingsRequest request, string currentUser)
        {
            return new CompanySettingsDto(
                request.CompanyID,
                request.CurrencyCode,
                request.TaxRate,
                request.LogoPath,
                request.DefaultLanguage,
                DateTime.UtcNow
            );
        }
    }
}
