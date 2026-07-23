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
    public class ClientTypeRepository : IClientTypeRepository
    {
        private readonly string _cs;

        public ClientTypeRepository(IConfiguration config)
        {
            _cs = config.GetConnectionString("DefaultConnection")!;
        }

        public List<ClientTypeDto> GetAll(bool? isActive = null)
        {
            var list = new List<ClientTypeDto>();

            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand("core.SP_ClientType_GetAll", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IsActive", (object?)isActive ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrentUser", "System");

            conn.Open();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new ClientTypeDto(
                    reader.GetInt32(reader.GetOrdinal("ClientTypeID")),
                    reader.GetString(reader.GetOrdinal("ClientTypeName")),
                    reader.GetBoolean(reader.GetOrdinal("IsActive")),
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                    reader.GetString(reader.GetOrdinal("CreatedBy")),
                    reader["UpdatedAt"] as DateTime?,
                    reader["UpdatedBy"] as string
                ));
            }

            return list;
        }

        public ClientTypeDto? GetById(int clientTypeId)
        {
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand("core.SP_ClientType_GetByID", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientTypeID", clientTypeId);
            cmd.Parameters.AddWithValue("@CurrentUser", "System");

            conn.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new ClientTypeDto(
                    reader.GetInt32(reader.GetOrdinal("ClientTypeID")),
                    reader.GetString(reader.GetOrdinal("ClientTypeName")),
                    reader.GetBoolean(reader.GetOrdinal("IsActive")),
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                    reader.GetString(reader.GetOrdinal("CreatedBy")),
                    reader["UpdatedAt"] as DateTime?,
                    reader["UpdatedBy"] as string
                );
            }

            return null;
        }

        public int Add(ClientTypeDto clientType, string currentUser)
        {
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand("core.SP_ClientType_Add", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ClientTypeName", clientType.ClientTypeName);
            cmd.Parameters.AddWithValue("@CurrentUser", currentUser);

            conn.Open();

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool Update(ClientTypeDto clientType, string currentUser)
        {
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand("core.SP_ClientType_Update", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ClientTypeID", clientType.ClientTypeID);
            cmd.Parameters.AddWithValue("@ClientTypeName", clientType.ClientTypeName);
            cmd.Parameters.AddWithValue("@CurrentUser", currentUser);

            conn.Open();

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Deactivate(int clientTypeId)
        {
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand("core.SP_ClientType_Deactivate", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ClientTypeID", clientTypeId);
            cmd.Parameters.AddWithValue("@CurrentUser", "System");

            conn.Open();

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Reactivate(int clientTypeId)
        {
            using var conn = new SqlConnection(_cs);
            using var cmd = new SqlCommand("core.SP_ClientType_Reactivate", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ClientTypeID", clientTypeId);
            cmd.Parameters.AddWithValue("@CurrentUser", "System");

            conn.Open();

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
