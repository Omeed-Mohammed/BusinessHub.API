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
    public class ClientRepository : IClientRepository
    {
        private readonly string _cs;

        public ClientRepository(IConfiguration config)
        {
            _cs = config.GetConnectionString("DefaultConnection")!;
        }

        public List<ClientDto> GetByCompanyId(int companyId)
        {
            var clients = new List<ClientDto>();

            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("core.SP_Client_GetByCompanyID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", companyId);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int id = reader.GetOrdinal("ClientID");
                    int compId = reader.GetOrdinal("CompanyID");
                    int name = reader.GetOrdinal("ClientName");
                    int phone = reader.GetOrdinal("Phone");
                    int email = reader.GetOrdinal("Email");
                    int address = reader.GetOrdinal("Address");
                    int note = reader.GetOrdinal("Note");
                    int isActive = reader.GetOrdinal("IsActive");
                    int createdAt = reader.GetOrdinal("CreatedAt");
                    int createdBy = reader.GetOrdinal("CreatedBy");
                    int updatedAt = reader.GetOrdinal("UpdatedAt");
                    int updatedBy = reader.GetOrdinal("UpdatedBy");

                    while (reader.Read())
                    {
                        clients.Add(new ClientDto(
                            reader.GetInt32(id),
                            reader.GetInt32(compId),
                            reader.GetString(name),
                            reader.IsDBNull(phone) ? null : reader.GetString(phone),
                            reader.IsDBNull(email) ? null : reader.GetString(email),
                            reader.IsDBNull(address) ? null : reader.GetString(address),
                            reader.IsDBNull(note) ? null : reader.GetString(note),
                            reader.GetBoolean(isActive),
                            reader.IsDBNull(createdAt) ? (DateTime?)null : reader.GetDateTime(createdAt),
                            reader.IsDBNull(createdBy) ? null : reader.GetString(createdBy),
                            reader.IsDBNull(updatedAt) ? (DateTime?)null : reader.GetDateTime(updatedAt),
                            reader.IsDBNull(updatedBy) ? null : reader.GetString(updatedBy)
                        ));
                    }
                }
            }

            return clients;
        }

        public ClientDto? GetById(int clientId)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("core.SP_Client_GetByID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", clientId);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ClientDto(
                            reader.GetInt32(reader.GetOrdinal("ClientID")),
                            reader.GetInt32(reader.GetOrdinal("CompanyID")),
                            reader.GetString(reader.GetOrdinal("ClientName")),
                            reader["Phone"] as string,
                            reader["Email"] as string,
                            reader["Address"] as string,
                            reader["Note"] as string,
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

        public int Add(ClientDto client, string currentUser)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("core.SP_Client_Add", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CompanyID", client.CompanyID);
                cmd.Parameters.AddWithValue("@ClientName", client.ClientName);
                cmd.Parameters.AddWithValue("@Phone", (object?)client.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object?)client.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", (object?)client.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Note", (object?)client.Note ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CurrentUser", currentUser);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool Update(ClientDto client, string currentUser)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("core.SP_Client_Update", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ClientID", client.ClientID);
                cmd.Parameters.AddWithValue("@CompanyID", client.CompanyID);
                cmd.Parameters.AddWithValue("@ClientName", client.ClientName);
                cmd.Parameters.AddWithValue("@Phone", (object?)client.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object?)client.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", (object?)client.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Note", (object?)client.Note ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CurrentUser", currentUser);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Deactivate(int clientId)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("core.SP_Client_Deactivate", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", clientId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Reactivate(int clientId)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("core.SP_Client_Reactivate", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", clientId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
