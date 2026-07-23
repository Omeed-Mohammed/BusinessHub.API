using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Core.Services
{
    public class CompanyService
    {
        private readonly ICompanyRepository _repo;

        public CompanyService(ICompanyRepository repo)
        {
            _repo = repo;
        }

        public int AddCompany(CompanyDto company, string currentUser)
        {
            if (company == null)
                throw new ArgumentException("Invalid data");

            return _repo.AddCompany(company, currentUser);
        }

        public bool UpdateCompany(CompanyDto company, string currentUser)
        {
            if (company == null || company.CompanyID <= 0)
                throw new ArgumentException("Invalid data");

            return _repo.UpdateCompany(company, currentUser);
        }

        public List<CompanyDto> GetAll(string currentUser, bool? isActive = null)
        {
            return _repo.GetAll(currentUser, isActive) ?? new List<CompanyDto>();
        }

        public CompanyDto GetCompanyById(int companyId, string currentUser)
        {
            if (companyId <= 0)
                throw new ArgumentException("Invalid CompanyID");

            var company = _repo.GetCompanyById(companyId, currentUser);

            if (company == null)
                throw new KeyNotFoundException("Company not found");

            return company;
        }

        public bool DeactivateCompany(int companyId, string currentUser)
        {
            if (companyId <= 0)
                throw new ArgumentException("Invalid CompanyID");

            return _repo.DeactivateCompany(companyId, currentUser);
        }

        public bool ReactivateCompany(int companyId, string currentUser)
        {
            if (companyId <= 0)
                throw new ArgumentException("Invalid CompanyID");

            return _repo.ReactivateCompany(companyId, currentUser);
        }
    }
}
