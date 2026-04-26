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
    public class CompanySettingsRepository : ICompanySettingsRepository
    {
        private readonly string _cs;

        public CompanySettingsRepository(IConfiguration config)
        {
            _cs = config.GetConnectionString("DefaultConnection")!;
        }

        public bool Add(CompanySettingsDto settings, string currentUser)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("core.SP_CompanySettings_Add", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CompanyID", settings.CompanyID);
            command.Parameters.AddWithValue("@CurrencyCode", settings.CurrencyCode);
            command.Parameters.AddWithValue("@TaxRate", settings.TaxRate);
            command.Parameters.AddWithValue("@LogoPath", (object?)settings.LogoPath ?? DBNull.Value);
            command.Parameters.AddWithValue("@DefaultLanguage", (object?)settings.DefaultLanguage ?? DBNull.Value);
            command.Parameters.AddWithValue("@CurrentUser", currentUser);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public CompanySettingsDto? GetByCompanyId(int companyId)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("core.SP_CompanySettings_GetByCompanyID", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CompanyID", companyId);

            connection.Open();

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new CompanySettingsDto(
                    reader.GetInt32(reader.GetOrdinal("CompanyID")),
                    reader.GetString(reader.GetOrdinal("CurrencyCode")),
                    reader.GetDecimal(reader.GetOrdinal("TaxRate")),
                    reader["LogoPath"] as string,
                    reader["DefaultLanguage"] as string,
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                );
            }

            return null;
        }

        public bool Update(CompanySettingsDto settings, string currentUser)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("core.SP_CompanySettings_Update", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CompanyID", settings.CompanyID);
            command.Parameters.AddWithValue("@CurrencyCode", settings.CurrencyCode);
            command.Parameters.AddWithValue("@TaxRate", settings.TaxRate);
            command.Parameters.AddWithValue("@LogoPath", (object?)settings.LogoPath ?? DBNull.Value);
            command.Parameters.AddWithValue("@DefaultLanguage", (object?)settings.DefaultLanguage ?? DBNull.Value);
            command.Parameters.AddWithValue("@CurrentUser", currentUser);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }
    }
}
