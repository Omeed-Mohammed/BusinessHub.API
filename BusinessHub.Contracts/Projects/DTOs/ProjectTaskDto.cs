using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Projects.DTOs
{
    public class ProjectTaskDto
    {
        public int TaskID { get; set; }

        public int ProjectID { get; set; }

        public string TaskName { get; set; }

        public string? Description { get; set; }

        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public decimal ProgressPercent { get; set; }

        public int StatusID { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public decimal Weight { get; set; }

        public bool IsActive { get; set; }

        public ProjectTaskDto(
            int taskID,
            int projectID,
            string taskName,
            string? description,
            DateOnly? startDate,
            DateOnly? endDate,
            decimal progressPercent,
            int statusID,
            DateTime createdAt,
            string createdBy,
            DateTime? updatedAt,
            string? updatedBy,
            decimal weight,
            bool isActive)
        {
            TaskID = taskID;
            ProjectID = projectID;
            TaskName = taskName;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            ProgressPercent = progressPercent;
            StatusID = statusID;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            Weight = weight;
            IsActive = isActive;
        }
    }
}
