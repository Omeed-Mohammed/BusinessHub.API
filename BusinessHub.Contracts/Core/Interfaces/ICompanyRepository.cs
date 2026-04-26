using BusinessHub.Contracts.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Core.Interfaces
{
    public interface ICompanyRepository
    {
        List<CompanyDto> GetAllCompanies();
        CompanyDto? GetCompanyById(int companyId);

        int AddCompany(CompanyDto company, string currentUser);
        bool UpdateCompany(CompanyDto company, string currentUser);

        bool DeactivateCompany(int companyId);
        bool ReactivateCompany(int companyId);
    }
}
