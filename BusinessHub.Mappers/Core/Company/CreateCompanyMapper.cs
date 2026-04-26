using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Requests.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Core.Company
{
    public class CreateCompanyMapper
    {
        public static CompanyDto ToDto(CreateCompanyRequest request, string currentUser)
        {
            return new CompanyDto(
                0,
                request.CompanyName,
                request.BusinessType!,
                request.LicenseNumber,
                request.Phone,
                request.Email,
                request.Website,
                request.Country,
                request.City,
                request.AddressLine,
                request.LogoPath,
                true,
                DateTime.UtcNow,
                currentUser,
                null,
                null
            );
        }
    }
}
