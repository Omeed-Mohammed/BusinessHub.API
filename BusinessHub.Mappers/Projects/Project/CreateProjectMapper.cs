using BusinessHub.Contracts.Projects.DTOs;
using BusinessHub.Contracts.Projects.Requests.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Projects.Project
{
    public class CreateProjectMapper
    {
        public static ProjectDto ToDto(CreateProjectRequestDto request, string currentUser)
        {
            return new ProjectDto(
                0,
                request.BranchID,
                request.ProjectName,
                request.ClientID,
                request.TotalBudget,
                request.StartDate,
                request.EndDate,
                true,
                request.StatusID,
                request.Notes,
                DateTime.UtcNow,
                currentUser,
                null,
                null
            );
        }
    }
}
