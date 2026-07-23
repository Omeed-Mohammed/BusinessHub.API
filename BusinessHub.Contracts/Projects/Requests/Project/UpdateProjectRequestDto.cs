using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Projects.Requests.Project
{
    public class UpdateProjectRequestDto
    {
        public int ProjectID { get; set; }

        public int BranchID { get; set; }

        public string ProjectName { get; set; }

        public int? ClientID { get; set; }

        public decimal? TotalBudget { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public int StatusID { get; set; }

        public string? Notes { get; set; }

        public UpdateProjectRequestDto(
            int projectID,
            int branchID,
            string projectName,
            int? clientID,
            decimal? totalBudget,
            DateOnly startDate,
            DateOnly? endDate,
            int statusID,
            string? notes)
        {
            ProjectID = projectID;
            BranchID = branchID;
            ProjectName = projectName;
            ClientID = clientID;
            TotalBudget = totalBudget;
            StartDate = startDate;
            EndDate = endDate;
            StatusID = statusID;
            Notes = notes;
        }
    }
}
