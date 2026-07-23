using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.DebtFlow.DTOs.Supplier
{
    public class SupplierDto
    {
        public int SupplierID { get; set; }
        public int CompanyID { get; set; }

        public string FullName { get; set; }
        public string Phone { get; set; }

        public string? Address { get; set; }
        public string? Note { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public SupplierDto(
            int supplierID,
            int companyID,
            string fullName,
            string phone,
            string? address,
            string? note,
            bool isActive,
            string createdBy,
            DateTime createdAt,
            string? updatedBy,
            DateTime? updatedAt)
        {
            SupplierID = supplierID;
            CompanyID = companyID;
            FullName = fullName;
            Phone = phone;
            Address = address;
            Note = note;
            IsActive = isActive;
            CreatedBy = createdBy;
            CreatedAt = createdAt;
            UpdatedBy = updatedBy;
            UpdatedAt = updatedAt;
        }
    }
}
