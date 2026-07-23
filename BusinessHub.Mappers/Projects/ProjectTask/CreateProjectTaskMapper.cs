using BusinessHub.Contracts.Projects.DTOs;
using BusinessHub.Contracts.Projects.Requests.ProjectTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Projects.ProjectTask
{
    public class CreateProjectTaskMapper
    {
        public static ProjectTaskDto ToDto(CreateProjectTaskRequestDto request, string currentUser)
        {
            return new ProjectTaskDto(
                0,
                request.ProjectID,
                request.TaskName,
                request.Description,
                request.StartDate,
                request.EndDate,
                request.ProgressPercent,
                request.StatusID,
                DateTime.UtcNow,
                currentUser,
                null,
                null,
                request.Weight,
                true
            );
        }
    }
}
