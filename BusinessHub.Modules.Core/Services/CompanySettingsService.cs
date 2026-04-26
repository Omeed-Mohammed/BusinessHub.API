using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Core.Services
{
    public class CompanySettingsService
    {
        private readonly ICompanySettingsRepository _repo;

        public CompanySettingsService(ICompanySettingsRepository repo)
        {
            _repo = repo;
        }

        public bool Add(CompanySettingsDto settings, string currentUser)
        {
            if (settings == null)
                throw new ArgumentException("Invalid data");

            if (settings.CompanyID <= 0)
                throw new ArgumentException("CompanyID required");

            if (string.IsNullOrWhiteSpace(settings.CurrencyCode))
                throw new ArgumentException("CurrencyCode required");

            return _repo.Add(settings, currentUser);
        }

        public bool Update(CompanySettingsDto settings, string currentUser)
        {
            if (settings == null || settings.CompanyID <= 0)
                throw new ArgumentException("Invalid data");

            return _repo.Update(settings, currentUser);
        }

        public CompanySettingsDto GetByCompanyId(int companyId)
        {
            if (companyId <= 0)
                throw new ArgumentException("Invalid CompanyID");

            var settings = _repo.GetByCompanyId(companyId);

            if (settings == null)
                throw new KeyNotFoundException("Settings not found");

            return settings;
        }
    }
}
