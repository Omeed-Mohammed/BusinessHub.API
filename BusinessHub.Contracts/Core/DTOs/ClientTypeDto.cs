using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Core.DTOs
{
    public class ClientTypeDto
    {
        public int ClientTypeID { get; set; }
        public string ClientTypeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public ClientTypeDto(
            int clientTypeID,
            string clientTypeName,
            bool isActive,
            DateTime createdAt,
            string createdBy,
            DateTime? updatedAt,
            string? updatedBy)
        {
            ClientTypeID = clientTypeID;
            ClientTypeName = clientTypeName;
            IsActive = isActive;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }
    }
}
