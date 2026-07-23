using BusinessHub.Contracts.Projects.DTOs;
using BusinessHub.Contracts.Projects.Requests.ProjectTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Projects.ProjectTask
{
    public class UpdateProjectTaskMapper
    {
        public static ProjectTaskDto ToDto(UpdateProjectTaskRequestDto request, string currentUser)
        {
            return new ProjectTaskDto(
                request.TaskID,
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
