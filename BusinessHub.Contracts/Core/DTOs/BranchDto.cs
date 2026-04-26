using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Core.DTOs
{
    public class BranchDto
    {
        public int BranchID { get; set; }
        public int CompanyID { get; set; }
        public string BranchName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public BranchDto(
            int branchID,
            int companyID,
            string branchName,
            string? address,
            string? city,
            string? phone,
            bool isActive,
            DateTime? createdAt,
            string? createdBy,
            DateTime? updatedAt,
            string? updatedBy)
        {
            BranchID = branchID;
            CompanyID = companyID;
            BranchName = branchName;
            Address = address;
            City = city;
            Phone = phone;
            IsActive = isActive;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }
    }
}
