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
        List<CompanyDto> GetAll(string currentUser, bool? isActive = null);
        CompanyDto? GetCompanyById(int companyId, string currentUser);

        int AddCompany(CompanyDto company, string currentUser);
        bool UpdateCompany(CompanyDto company, string currentUser);

        bool DeactivateCompany(int companyId, string currentUser);
        bool ReactivateCompany(int companyId, string currentUser);
    }
}
