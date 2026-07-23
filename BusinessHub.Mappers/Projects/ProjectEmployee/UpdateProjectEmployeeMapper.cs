using BusinessHub.Contracts.Projects.DTOs;
using BusinessHub.Contracts.Projects.Requests.ProjectEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Projects.ProjectEmployee
{
    public class UpdateProjectEmployeeMapper
    {
        public static ProjectEmployeeDto ToDto(UpdateProjectEmployeeRequestDto request, string currentUser)
        {
            return new ProjectEmployeeDto(
                request.ProjectEmployeeID,
                request.ProjectID,
                request.EmployeeID,
                request.Role,
                request.StartDate,
                request.EndDate,
                true,
                DateTime.UtcNow,
                currentUser,
                null,
                null
            );
        }
    }
}
