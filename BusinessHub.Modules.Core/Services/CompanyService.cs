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

            if (string.IsNullOrWhiteSpace(company.CompanyName))
                throw new ArgumentException("CompanyName required");

            if (string.IsNullOrWhiteSpace(company.Country))
                throw new ArgumentException("Country required");

            if (string.IsNullOrWhiteSpace(company.City))
                throw new ArgumentException("City required");

            return _repo.AddCompany(company, currentUser);
        }

        public bool UpdateCompany(CompanyDto company, string currentUser)
        {
            if (company == null || company.CompanyID <= 0)
                throw new ArgumentException("Invalid data");

            return _repo.UpdateCompany(company, currentUser);
        }

        public List<CompanyDto> GetAllCompanies()
        {
            return _repo.GetAllCompanies() ?? new List<CompanyDto>();
        }

        public CompanyDto GetCompanyById(int companyId)
        {
            if (companyId <= 0)
                throw new ArgumentException("Invalid CompanyID");

            var company = _repo.GetCompanyById(companyId);

            if (company == null)
                throw new KeyNotFoundException("Company not found");

            return company;
        }

        public bool DeactivateCompany(int companyId)
        {
            if (companyId <= 0)
                throw new ArgumentException("Invalid CompanyID");

            return _repo.DeactivateCompany(companyId);
        }

        public bool ReactivateCompany(int companyId)
        {
            if (companyId <= 0)
                throw new ArgumentException("Invalid CompanyID");

            return _repo.ReactivateCompany(companyId);
        }
    }
}
