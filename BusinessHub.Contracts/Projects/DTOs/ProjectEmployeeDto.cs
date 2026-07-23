using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Projects.DTOs
{
    public class ProjectEmployeeDto
    {
        public int ProjectEmployeeID { get; set; }

        public int ProjectID { get; set; }

        public int EmployeeID { get; set; }

        public string? Role { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public ProjectEmployeeDto(
            int projectEmployeeID,
            int projectID,
            int employeeID,
            string? role,
            DateOnly startDate,
            DateOnly? endDate,
            bool? isActive,
            DateTime? createdAt,
            string? createdBy,
            DateTime? updatedAt,
            string? updatedBy)
        {
            ProjectEmployeeID = projectEmployeeID;
            ProjectID = projectID;
            EmployeeID = employeeID;
            Role = role;
            StartDate = startDate;
            EndDate = endDate;
            IsActive = isActive;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }
    }
}
