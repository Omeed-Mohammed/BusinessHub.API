using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Projects.Requests.ProjectEmployee
{
    public class UpdateProjectEmployeeRequestDto
    {
        public int ProjectEmployeeID { get; set; }

        public int ProjectID { get; set; }

        public int EmployeeID { get; set; }

        public string? Role { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public UpdateProjectEmployeeRequestDto(
            int projectEmployeeID,
            int projectID,
            int employeeID,
            string? role,
            DateOnly startDate,
            DateOnly? endDate)
        {
            ProjectEmployeeID = projectEmployeeID;
            ProjectID = projectID;
            EmployeeID = employeeID;
            Role = role;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
