using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Core.DTOs
{
    public class CompanyDto
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string BusinessType { get; set; }
        public string? LicenseNumber { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string? AddressLine { get; set; }
        public string? LogoPath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }


        public CompanyDto(
    int companyID,
    string companyName,
    string businessType,
    string? licenseNumber,
    string? phone,
    string? email,
    string? website,
    string country,
    string city,
    string? addressLine,
    string? logoPath,
    bool isActive,
    DateTime createdAt,
    string createdBy,
    DateTime? updatedAt,
    string? updatedBy)
        {
            CompanyID = companyID;
            CompanyName = companyName;
            BusinessType = businessType;
            LicenseNumber = licenseNumber;
            Phone = phone;
            Email = email;
            Website = website;
            Country = country;
            City = city;
            AddressLine = addressLine;
            LogoPath = logoPath;
            IsActive = isActive;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }
    }
}
