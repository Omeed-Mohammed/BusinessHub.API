using BusinessHub.Contracts.Core.Requests.Company;
using BusinessHub.Contracts.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Core.Company
{
    public class UpdateCompanyMapper
    {
        public static CompanyDto ToDto(UpdateCompanyRequest request, string currentUser)
        {
            return new CompanyDto(
                request.CompanyID,
                request.CompanyName,
                request.BusinessType ?? string.Empty,
                request.LicenseNumber,
                request.Phone,
                request.Email,
                request.Website,
                request.Country,
                request.City,
                request.AddressLine,
                request.LogoPath,
                true,
                DateTime.UtcNow,   // ignored in DB update
                currentUser,
                DateTime.UtcNow,
                currentUser
            );
        }
    }
}
