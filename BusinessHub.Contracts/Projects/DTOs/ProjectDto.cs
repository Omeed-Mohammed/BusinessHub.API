using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Projects.DTOs
{
    public class ProjectDto
    {
        public int ProjectID { get; set; }

        public int BranchID { get; set; }

        public string ProjectName { get; set; }

        public int? ClientID { get; set; }

        public decimal? TotalBudget { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public bool? IsActive { get; set; }

        public int StatusID { get; set; }

        public string? Notes { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public ProjectDto(
            int projectID,
            int branchID,
            string projectName,
            int? clientID,
            decimal? totalBudget,
            DateOnly startDate,
            DateOnly? endDate,
            bool? isActive,
            int statusID,
            string? notes,
            DateTime? createdAt,
            string? createdBy,
            DateTime? updatedAt,
            string? updatedBy)
        {
            ProjectID = projectID;
            BranchID = branchID;
            ProjectName = projectName;
            ClientID = clientID;
            TotalBudget = totalBudget;
            StartDate = startDate;
            EndDate = endDate;
            IsActive = isActive;
            StatusID = statusID;
            Notes = notes;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }
    }
}
