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
    public class BranchRepository : IBranchRepository
    {
        private readonly string _cs;

        public BranchRepository(IConfiguration config)
        {
            _cs = config.GetConnectionString("DefaultConnection")!;
        }

        public List<BranchDto> GetAll(bool? isActive = null)
        {
            var list = new List<BranchDto>();

            using var connection = new SqlConnection(_cs);
            using var command = new SqlCommand("core.SP_Branch_GetAll", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@IsActive", SqlDbType.Bit).Value =
                (object?)isActive ?? DBNull.Value;

            command.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 100).Value =
                "System";

            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new BranchDto(
                    reader.GetInt32(reader.GetOrdinal("BranchID")),
                    reader.GetInt32(reader.GetOrdinal("CompanyID")),
                    reader.GetString(reader.GetOrdinal("BranchName")),
                    reader["Address"] as string,
                    reader["City"] as string,
                    reader["Phone"] as string,
                    reader.GetBoolean(reader.GetOrdinal("IsActive")),
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                    reader.GetString(reader.GetOrdinal("CreatedBy")),
                    reader["UpdatedAt"] as DateTime?,
                    reader["UpdatedBy"] as string
                ));
            }

            return list;
        }

        public List<BranchDto> GetByCompanyId(int companyId)
        {
            var list = new List<BranchDto>();

            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("core.SP_Branch_GetByCompanyID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", companyId);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int id = reader.GetOrdinal("BranchID");
                    int compId = reader.GetOrdinal("CompanyID");
                    int name = reader.GetOrdinal("BranchName");
                    int address = reader.GetOrdinal("Address");
                    int phone = reader.GetOrdinal("Phone");
                    int isActive = reader.GetOrdinal("IsActive");
                    int createdAt = reader.GetOrdinal("CreatedAt");
                    int createdBy = reader.GetOrdinal("CreatedBy");
                    int updatedAt = reader.GetOrdinal("UpdatedAt");
                    int updatedBy = reader.GetOrdinal("UpdatedBy");

                    while (reader.Read())
                    {
                        list.Add(new BranchDto(
                            reader.GetInt32(id),
                            reader.GetInt32(compId),
                            reader.GetString(name),
                            reader.IsDBNull(address) ? null : reader.GetString(address),
                            null,
                            reader.IsDBNull(phone) ? null : reader.GetString(phone),
                            reader.GetBoolean(isActive),
                            reader.IsDBNull(createdAt) ? (DateTime?)null : reader.GetDateTime(createdAt),
                            reader.IsDBNull(createdBy) ? null : reader.GetString(createdBy),
                            reader.IsDBNull(updatedAt) ? (DateTime?)null : reader.GetDateTime(updatedAt),
                            reader.IsDBNull(updatedBy) ? null : reader.GetString(updatedBy)
                        ));
                    }
                }
            }

            return list;
        }

        public BranchDto? GetById(int branchId)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("core.SP_Branch_GetByID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BranchID", branchId);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new BranchDto(
                            reader.GetInt32(reader.GetOrdinal("BranchID")),
                            reader.GetInt32(reader.GetOrdinal("CompanyID")),
                            reader.GetString(reader.GetOrdinal("BranchName")),
                            reader["Address"] as string,
                            null,
                            reader["Phone"] as string,
                            reader.GetBoolean(reader.GetOrdinal("IsActive")),
                            reader["CreatedAt"] as DateTime?,
                            reader["CreatedBy"] as string,
                            reader["UpdatedAt"] as DateTime?,
                            reader["UpdatedBy"] as string
                        );
                    }
                }
            }

            return null;
        }

        public int Add(BranchDto branch, string currentUser)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("core.SP_Branch_Add", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CompanyID", branch.CompanyID);
                cmd.Parameters.AddWithValue("@BranchName", branch.BranchName);
                cmd.Parameters.AddWithValue("@Address", (object?)branch.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", (object?)branch.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CurrentUser", currentUser);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool Update(BranchDto branch, string currentUser)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("core.SP_Branch_Update", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BranchID", branch.BranchID);
                cmd.Parameters.AddWithValue("@CompanyID", branch.CompanyID);
                cmd.Parameters.AddWithValue("@BranchName", branch.BranchName);
                cmd.Parameters.AddWithValue("@Address", (object?)branch.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", (object?)branch.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CurrentUser", currentUser);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Deactivate(int branchId)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("core.SP_Branch_Deactivate", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BranchID", branchId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Reactivate(int branchId)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("core.SP_Branch_Reactivate", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BranchID", branchId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
