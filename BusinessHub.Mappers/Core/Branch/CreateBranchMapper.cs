using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Requests.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Core.Branch
{
    public class CreateBranchMapper
    {
        public static BranchDto ToDto(CreateBranchRequest request, string currentUser)
        {
            return new BranchDto(
                0,
                request.CompanyID,
                request.BranchName,
                request.Address,
                null, // City not in SP
                request.Phone,
                true,
                DateTime.UtcNow,
                currentUser,
                null,
                null
            );
        }
    }
}
