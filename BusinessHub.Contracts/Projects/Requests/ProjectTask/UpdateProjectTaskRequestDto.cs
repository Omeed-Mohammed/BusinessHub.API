using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Projects.Requests.ProjectTask
{
    public class UpdateProjectTaskRequestDto
    {
        public int TaskID { get; set; }

        public int ProjectID { get; set; }

        public string TaskName { get; set; }

        public string? Description { get; set; }

        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public decimal ProgressPercent { get; set; }

        public int StatusID { get; set; }

        public decimal Weight { get; set; }

        public UpdateProjectTaskRequestDto(
            int taskID,
            int projectID,
            string taskName,
            string? description,
            DateOnly? startDate,
            DateOnly? endDate,
            decimal progressPercent,
            int statusID,
            decimal weight)
        {
            TaskID = taskID;
            ProjectID = projectID;
            TaskName = taskName;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            ProgressPercent = progressPercent;
            StatusID = statusID;
            Weight = weight;
        }
    }
}
