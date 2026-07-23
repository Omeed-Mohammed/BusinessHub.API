using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Projects.Requests.ProjectEmployee
{
    public class CreateProjectEmployeeRequestDto
    {
        public int ProjectID { get; set; }

        public int EmployeeID { get; set; }

        public string? Role { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public CreateProjectEmployeeRequestDto(
            int projectID,
            int employeeID,
            string? role,
            DateOnly startDate,
            DateOnly? endDate)
        {
            ProjectID = projectID;
            EmployeeID = employeeID;
            Role = role;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
