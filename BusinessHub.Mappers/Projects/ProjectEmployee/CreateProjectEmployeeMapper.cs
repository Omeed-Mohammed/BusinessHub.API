using BusinessHub.Contracts.Projects.DTOs;
using BusinessHub.Contracts.Projects.Requests.ProjectEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Projects.ProjectEmployee
{
    public class CreateProjectEmployeeMapper
    {
        public static ProjectEmployeeDto ToDto(CreateProjectEmployeeRequestDto request, string currentUser)
        {
            return new ProjectEmployeeDto(
                0,
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
