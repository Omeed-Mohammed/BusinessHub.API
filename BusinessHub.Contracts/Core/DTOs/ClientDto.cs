using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Core.DTOs
{
    public class ClientDto
    {
        public int ClientID { get; set; }
        public int CompanyID { get; set; }
        public string ClientName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Note { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public ClientDto(
            int clientID,
            int companyID,
            string clientName,
            string? phone,
            string? email,
            string? address,
            string? note,
            bool isActive,
            DateTime? createdAt,
            string? createdBy,
            DateTime? updatedAt,
            string? updatedBy)
        {
            ClientID = clientID;
            CompanyID = companyID;
            ClientName = clientName;
            Phone = phone;
            Email = email;
            Address = address;
            Note = note;
            IsActive = isActive;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }
    }
}
