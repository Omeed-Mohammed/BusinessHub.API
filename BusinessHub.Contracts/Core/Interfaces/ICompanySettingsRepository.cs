using BusinessHub.Contracts.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Core.Interfaces
{
    public interface ICompanySettingsRepository
    {
        CompanySettingsDto? GetByCompanyId(int companyId, string currentUser);

        bool Add(CompanySettingsDto settings, string currentUser);
        bool Update(CompanySettingsDto settings, string currentUser);
    }
}
