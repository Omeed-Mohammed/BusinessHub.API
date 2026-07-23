using BusinessHub.Contracts.DebtFlow.DTOs.Supplier;
using BusinessHub.Contracts.DebtFlow.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Infrastructure.DebtFlow.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly string _cs;

        public SupplierRepository(IConfiguration config)
        {
            _cs = config.GetConnectionString("DefaultConnection")!;
        }

        public List<SupplierDto> GetAllSuppliers(bool? isActive = true)
        {
            var suppliersList = new List<SupplierDto>();

            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("SP_Supplier_GetAll", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(
                "@IsActive",
                SqlDbType.Bit).Value = (object?)isActive ?? DBNull.Value;

            connection.Open();

            using var reader = command.ExecuteReader();

            int supplierIdIndex = reader.GetOrdinal("SupplierID");
            int companyIdIndex = reader.GetOrdinal("CompanyID");
            int fullNameIndex = reader.GetOrdinal("FullName");
            int phoneIndex = reader.GetOrdinal("Phone");
            int addressIndex = reader.GetOrdinal("Address");
            int noteIndex = reader.GetOrdinal("Note");
            int isActiveIndex = reader.GetOrdinal("IsActive");
            int createdByIndex = reader.GetOrdinal("CreatedBy");
            int createdAtIndex = reader.GetOrdinal("CreatedAt");
            int updatedByIndex = reader.GetOrdinal("UpdatedBy");
            int updatedAtIndex = reader.GetOrdinal("UpdatedAt");

            while (reader.Read())
            {
                suppliersList.Add(
                    new SupplierDto(
                        reader.GetInt32(supplierIdIndex),
                        reader.GetInt32(companyIdIndex),
                        reader.GetString(fullNameIndex),
                        reader.GetString(phoneIndex),
                        reader.IsDBNull(addressIndex) ? null : reader.GetString(addressIndex),
                        reader.IsDBNull(noteIndex) ? null : reader.GetString(noteIndex),
                        reader.GetBoolean(isActiveIndex),
                        reader.GetString(createdByIndex),
                        reader.GetDateTime(createdAtIndex),
                        reader.IsDBNull(updatedByIndex) ? null : reader.GetString(updatedByIndex),
                        reader.IsDBNull(updatedAtIndex) ? null : reader.GetDateTime(updatedAtIndex)
                    ));
            }

            return suppliersList;
        }

        public SupplierDto? GetSupplierById(int supplierId)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("SP_Supplier_GetByID", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@SupplierID", SqlDbType.Int).Value = supplierId;

            connection.Open();

            using var reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            int supplierIdIndex = reader.GetOrdinal("SupplierID");
            int companyIdIndex = reader.GetOrdinal("CompanyID");
            int fullNameIndex = reader.GetOrdinal("FullName");
            int phoneIndex = reader.GetOrdinal("Phone");
            int addressIndex = reader.GetOrdinal("Address");
            int noteIndex = reader.GetOrdinal("Note");
            int isActiveIndex = reader.GetOrdinal("IsActive");
            int createdByIndex = reader.GetOrdinal("CreatedBy");
            int createdAtIndex = reader.GetOrdinal("CreatedAt");
            int updatedByIndex = reader.GetOrdinal("UpdatedBy");
            int updatedAtIndex = reader.GetOrdinal("UpdatedAt");

            return new SupplierDto(
                reader.GetInt32(supplierIdIndex),
                reader.GetInt32(companyIdIndex),
                reader.GetString(fullNameIndex),
                reader.GetString(phoneIndex),
                reader.IsDBNull(addressIndex) ? null : reader.GetString(addressIndex),
                reader.IsDBNull(noteIndex) ? null : reader.GetString(noteIndex),
                reader.GetBoolean(isActiveIndex),
                reader.GetString(createdByIndex),
                reader.GetDateTime(createdAtIndex),
                reader.IsDBNull(updatedByIndex) ? null : reader.GetString(updatedByIndex),
                reader.IsDBNull(updatedAtIndex) ? null : reader.GetDateTime(updatedAtIndex)
            );
        }

        public int AddSupplier(SupplierDto supplier)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("SP_Supplier_Add", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@CompanyID", SqlDbType.Int)
                .Value = supplier.CompanyID;

            command.Parameters.Add("@FullName", SqlDbType.NVarChar, 100)
                .Value = supplier.FullName;

            command.Parameters.Add("@Phone", SqlDbType.NVarChar, 20)
                .Value = supplier.Phone;

            command.Parameters.Add("@Address", SqlDbType.NVarChar, 250)
                .Value = (object?)supplier.Address ?? DBNull.Value;

            command.Parameters.Add("@Note", SqlDbType.NVarChar, 500)
                .Value = (object?)supplier.Note ?? DBNull.Value;

            command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 100)
                .Value = supplier.CreatedBy;

            connection.Open();

            object? result = command.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        public bool UpdateSupplier(SupplierDto supplier)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("SP_Supplier_Update", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@SupplierID", SqlDbType.Int)
                .Value = supplier.SupplierID;

            command.Parameters.Add("@FullName", SqlDbType.NVarChar, 100)
                .Value = supplier.FullName;

            command.Parameters.Add("@Phone", SqlDbType.NVarChar, 20)
                .Value = supplier.Phone;

            command.Parameters.Add("@Address", SqlDbType.NVarChar, 250)
                .Value = (object?)supplier.Address ?? DBNull.Value;

            command.Parameters.Add("@Note", SqlDbType.NVarChar, 500)
                .Value = (object?)supplier.Note ?? DBNull.Value;

            command.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 100)
                .Value = supplier.UpdatedBy!;

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }


        public bool DeactivateSupplier(int supplierId, string currentUser)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("SP_Supplier_Deactivate", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@SupplierID", SqlDbType.Int)
                .Value = supplierId;

            command.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 100)
                .Value = currentUser;

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }


        public bool ReactivateSupplier(int supplierId, string currentUser)
        {
            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("SP_Supplier_Reactivate", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@SupplierID", SqlDbType.Int)
                .Value = supplierId;

            command.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 100)
                .Value = currentUser;

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }
    }
}
