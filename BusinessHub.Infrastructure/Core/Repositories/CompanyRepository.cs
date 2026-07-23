using BusinessHub.Contracts.Core.DTOs;
using BusinessHub.Contracts.Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Infrastructure.Core.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly string _cs;

        public CompanyRepository(IConfiguration config)
        {
            _cs = config.GetConnectionString("DefaultConnection")!;
        }

        public int AddCompany(CompanyDto company, string currentUser)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("core.SP_Company_Add", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 200)
                  .Value = company.CompanyName;
            command.Parameters.Add("@BusinessType", SqlDbType.NVarChar, 100).Value =
                (object?)company.BusinessType ?? DBNull.Value;

            command.Parameters.Add("@LicenseNumber", SqlDbType.NVarChar, 100).Value =
                (object?)company.LicenseNumber ?? DBNull.Value;

            command.Parameters.Add("@Phone", SqlDbType.NVarChar, 50).Value =
                (object?)company.Phone ?? DBNull.Value;

            command.Parameters.Add("@Email", SqlDbType.NVarChar, 255).Value =
                (object?)company.Email ?? DBNull.Value;

            command.Parameters.Add("@Website", SqlDbType.NVarChar, 500).Value =
                (object?)company.Website ?? DBNull.Value;

            command.Parameters.Add("@Country", SqlDbType.NVarChar, 100).Value =
                company.Country;

            command.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value =
                company.City;

            command.Parameters.Add("@AddressLine", SqlDbType.NVarChar, 500).Value =
                (object?)company.AddressLine ?? DBNull.Value;

            command.Parameters.Add("@LogoPath", SqlDbType.NVarChar, 500).Value =
                (object?)company.LogoPath ?? DBNull.Value;

            command.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 100).Value =
                currentUser;

            connection.Open();
            var result = command.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        public List<CompanyDto> GetAll(string currentUser, bool? isActive = null)
        {
            var list = new List<CompanyDto>();

            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("core.SP_Company_GetAll", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 100).Value = currentUser;
            command.Parameters.Add("@IsActive", SqlDbType.Bit).Value =
                              (object?)isActive ?? DBNull.Value;

            connection.Open();

            using var reader = command.ExecuteReader();

            int companyId = reader.GetOrdinal("CompanyID");
            int companyName = reader.GetOrdinal("CompanyName");
            int businessType = reader.GetOrdinal("BusinessType");
            int country = reader.GetOrdinal("Country");
            int city = reader.GetOrdinal("City");
            int isActiveOrdinal = reader.GetOrdinal("IsActive");
            int createdAt = reader.GetOrdinal("CreatedAt");
            int createdBy = reader.GetOrdinal("CreatedBy");

            while (reader.Read())
            {
                list.Add(new CompanyDto(
                    reader.GetInt32(companyId),
                    reader.GetString(companyName),
                    reader.IsDBNull(businessType) ? string.Empty : reader.GetString(businessType),
                    reader["LicenseNumber"] as string,
                    reader["Phone"] as string,
                    reader["Email"] as string,
                    reader["Website"] as string,
                    reader.GetString(country),
                    reader.GetString(city),
                    reader["AddressLine"] as string,
                    reader["LogoPath"] as string,
                    reader.GetBoolean(isActiveOrdinal),
                    reader.GetDateTime(createdAt),
                    reader.GetString(createdBy),
                    reader["UpdatedAt"] as DateTime?,
                    reader["UpdatedBy"] as string
                ));
            }

            return list;
        }

        public CompanyDto? GetCompanyById(int companyId, string currentUser)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("core.SP_Company_GetByID", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CompanyID", companyId);
            command.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 100).Value = currentUser;

            connection.Open();

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new CompanyDto(
                    reader.GetInt32(reader.GetOrdinal("CompanyID")),
                    reader.GetString(reader.GetOrdinal("CompanyName")),
                    reader.GetString(reader.GetOrdinal("BusinessType")),
                    reader["LicenseNumber"] as string,
                    reader["Phone"] as string,
                    reader["Email"] as string,
                    reader["Website"] as string,
                    reader.GetString(reader.GetOrdinal("Country")),
                    reader.GetString(reader.GetOrdinal("City")),
                    reader["AddressLine"] as string,
                    reader["LogoPath"] as string,
                    reader.GetBoolean(reader.GetOrdinal("IsActive")),
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                    reader.GetString(reader.GetOrdinal("CreatedBy")),
                    reader["UpdatedAt"] as DateTime?,
                    reader["UpdatedBy"] as string
                );
            }

            return null;
        }

        public bool UpdateCompany(CompanyDto company, string currentUser)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("core.SP_Company_Update", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@CompanyID", SqlDbType.Int).Value = company.CompanyID;
            command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 200).Value = company.CompanyName;
            command.Parameters.Add("@BusinessType", SqlDbType.NVarChar, 100).Value = (object?)company.BusinessType ?? DBNull.Value;
            command.Parameters.Add("@LicenseNumber", SqlDbType.NVarChar, 100).Value = (object?)company.LicenseNumber ?? DBNull.Value;
            command.Parameters.Add("@Phone", SqlDbType.NVarChar, 50).Value = (object?)company.Phone ?? DBNull.Value;
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = (object?)company.Email ?? DBNull.Value;
            command.Parameters.Add("@Website", SqlDbType.NVarChar, 150).Value = (object?)company.Website ?? DBNull.Value;
            command.Parameters.Add("@Country", SqlDbType.NVarChar, 100).Value = company.Country;
            command.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value = company.City;
            command.Parameters.Add("@AddressLine", SqlDbType.NVarChar, 250).Value = (object?)company.AddressLine ?? DBNull.Value;
            command.Parameters.Add("@LogoPath", SqlDbType.NVarChar, 250).Value = (object?)company.LogoPath ?? DBNull.Value;
            command.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 100).Value = currentUser;

            connection.Open();
            return Convert.ToInt32(command.ExecuteScalar()) == 1;
        }

        public bool DeactivateCompany(int companyId, string currentUser)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("core.SP_Company_Deactivate", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CompanyID", companyId);
            command.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 100).Value = currentUser;

            connection.Open();
            return Convert.ToInt32(command.ExecuteScalar()) == 1;
        }

        public bool ReactivateCompany(int companyId, string currentUser)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("core.SP_Company_Reactivate", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CompanyID", companyId);
            command.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 100).Value = currentUser;

            connection.Open();
            return Convert.ToInt32(command.ExecuteScalar()) == 1;
        }
    }
}
