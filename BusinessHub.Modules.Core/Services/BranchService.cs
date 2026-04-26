using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Core.Services
{
    public class BranchService
    {
        private readonly IBranchRepository _repo;

        public BranchService(IBranchRepository repo)
        {
            _repo = repo;
        }

        public int Add(BranchDto branch, string currentUser)
        {
            if (branch == null)
                throw new ArgumentException("Invalid data");

            if (branch.CompanyID <= 0)
                throw new ArgumentException("CompanyID required");

            if (string.IsNullOrWhiteSpace(branch.BranchName))
                throw new ArgumentException("BranchName required");

            return _repo.Add(branch, currentUser);
        }

        public bool Update(BranchDto branch, string currentUser)
        {
            if (branch == null || branch.BranchID <= 0)
                throw new ArgumentException("Invalid data");

            return _repo.Update(branch, currentUser);
        }

        public List<BranchDto> GetByCompanyId(int companyId)
        {
            if (companyId <= 0)
                throw new ArgumentException("Invalid CompanyID");

            return _repo.GetByCompanyId(companyId) ?? new List<BranchDto>();
        }

        public BranchDto GetById(int branchId)
        {
            if (branchId <= 0)
                throw new ArgumentException("Invalid BranchID");

            var branch = _repo.GetById(branchId);

            if (branch == null)
                throw new KeyNotFoundException("Branch not found");

            return branch;
        }

        public bool Deactivate(int branchId)
        {
            if (branchId <= 0)
                throw new ArgumentException("Invalid BranchID");

            return _repo.Deactivate(branchId);
        }

        public bool Reactivate(int branchId)
        {
            if (branchId <= 0)
                throw new ArgumentException("Invalid BranchID");

            return _repo.Reactivate(branchId);
        }
    }
}
