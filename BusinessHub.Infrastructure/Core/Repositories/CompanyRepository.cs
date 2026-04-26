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

            command.Parameters.AddWithValue("@CompanyName", company.CompanyName);
            command.Parameters.AddWithValue("@BusinessType", (object?)company.BusinessType ?? DBNull.Value);
            command.Parameters.AddWithValue("@LicenseNumber", (object?)company.LicenseNumber ?? DBNull.Value);
            command.Parameters.AddWithValue("@Phone", (object?)company.Phone ?? DBNull.Value);
            command.Parameters.AddWithValue("@Email", (object?)company.Email ?? DBNull.Value);
            command.Parameters.AddWithValue("@Website", (object?)company.Website ?? DBNull.Value);
            command.Parameters.AddWithValue("@Country", company.Country);
            command.Parameters.AddWithValue("@City", company.City);
            command.Parameters.AddWithValue("@AddressLine", (object?)company.AddressLine ?? DBNull.Value);
            command.Parameters.AddWithValue("@LogoPath", (object?)company.LogoPath ?? DBNull.Value);
            command.Parameters.AddWithValue("@CurrentUser", currentUser);

            connection.Open();
            var result = command.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        public List<CompanyDto> GetAllCompanies()
        {
            var list = new List<CompanyDto>();

            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("core.SP_Company_GetAll", connection);

            command.CommandType = CommandType.StoredProcedure;

            connection.Open();

            using var reader = command.ExecuteReader();

            int id = reader.GetOrdinal("CompanyID");
            int name = reader.GetOrdinal("CompanyName");

            while (reader.Read())
            {
                list.Add(new CompanyDto(
                    reader.GetInt32(id),
                    reader.GetString(name),
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
                ));
            }

            return list;
        }

        public CompanyDto? GetCompanyById(int companyId)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("core.SP_Company_GetByID", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CompanyID", companyId);

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

            command.Parameters.AddWithValue("@CompanyID", company.CompanyID);
            command.Parameters.AddWithValue("@CompanyName", company.CompanyName);
            command.Parameters.AddWithValue("@BusinessType", (object?)company.BusinessType ?? DBNull.Value);
            command.Parameters.AddWithValue("@LicenseNumber", (object?)company.LicenseNumber ?? DBNull.Value);
            command.Parameters.AddWithValue("@Phone", (object?)company.Phone ?? DBNull.Value);
            command.Parameters.AddWithValue("@Email", (object?)company.Email ?? DBNull.Value);
            command.Parameters.AddWithValue("@Website", (object?)company.Website ?? DBNull.Value);
            command.Parameters.AddWithValue("@Country", company.Country);
            command.Parameters.AddWithValue("@City", company.City);
            command.Parameters.AddWithValue("@AddressLine", (object?)company.AddressLine ?? DBNull.Value);
            command.Parameters.AddWithValue("@LogoPath", (object?)company.LogoPath ?? DBNull.Value);
            command.Parameters.AddWithValue("@CurrentUser", currentUser);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public bool DeactivateCompany(int companyId)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("core.SP_Company_Deactivate", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CompanyID", companyId);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public bool ReactivateCompany(int companyId)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("core.SP_Company_Reactivate", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CompanyID", companyId);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }
    }
}
