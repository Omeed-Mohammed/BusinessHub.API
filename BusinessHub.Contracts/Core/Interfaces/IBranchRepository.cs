using BusinessHub.Contracts.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Core.Interfaces
{
    public interface IBranchRepository
    {
        List<BranchDto> GetByCompanyId(int companyId);
        BranchDto? GetById(int branchId);

        int Add(BranchDto branch, string currentUser);
        bool Update(BranchDto branch, string currentUser);

        bool Deactivate(int branchId);
        bool Reactivate(int branchId);
    }
}
