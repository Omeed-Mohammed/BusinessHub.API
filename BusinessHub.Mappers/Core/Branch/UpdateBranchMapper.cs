using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Requests.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Core.Branch
{
    public class UpdateBranchMapper
    {
        public static BranchDto ToDto(UpdateBranchRequest request, string currentUser)
        {
            return new BranchDto(
                request.BranchID,
                request.CompanyID,
                request.BranchName,
                request.Address,
                null, // City not in SP
                request.Phone,
                true,
                DateTime.UtcNow, // ignored
                currentUser,
                DateTime.UtcNow,
                currentUser
            );
        }
    }
}
