using BusinessHub.Contracts.Identity.DTOs.Roles;
using BusinessHub.Contracts.Identity.Interfaces.Roles;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Infrastructure.Identity.Repositories.Roles
{
    public class RoleRepository : IRoleRepository
    {
        private readonly string _cs;

        public RoleRepository(IConfiguration config)
        {
            _cs = config.GetConnectionString("DefaultConnection")
                 ?? throw new InvalidOperationException("DefaultConnection was not found.");
        }

        public int AddRole(RoleDto role, string currentUser)
        {
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("SP_Role_Add", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@RoleName", SqlDbType.NVarChar, 100).Value = role.RoleName;

                command.Parameters.Add("@Description", SqlDbType.NVarChar, 250).Value =
                    (object?)role.Description ?? DBNull.Value;

                command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 100).Value =
                    (object)currentUser ?? DBNull.Value;

                connection.Open();
                var result = command.ExecuteScalar();

                return result is int id ? id : 0;
            }
        }

        public bool UpdateRole(RoleDto role, string currentUser)
        {
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("SP_Role_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = role.RoleID;

                command.Parameters.Add("@RoleName", SqlDbType.NVarChar, 100).Value = role.RoleName;

                command.Parameters.Add("@Description", SqlDbType.NVarChar, 250).Value =
                    (object?)role.Description ?? DBNull.Value;

                command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 100).Value =
                    (object)currentUser ?? DBNull.Value;


                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }


        public List<RoleDto> GetAllRoles()
        {
            var roles = new List<RoleDto>();

            using (SqlConnection conn = new SqlConnection(_cs))
            {


                using (SqlCommand cmd = new SqlCommand("SP_Role_GetAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int roleIDIndex = reader.GetOrdinal("RoleID");

                        int roleNameIndex = reader.GetOrdinal("RoleName");
                        int descriptionIndex = reader.GetOrdinal("Description");


                        int createdAtIndex = reader.GetOrdinal("CreatedAt");
                        int isActiveIndex = reader.GetOrdinal("IsActive");
                        int createdByIndex = reader.GetOrdinal("CreatedBy");


                        while (reader.Read())
                        {
                            string? description = reader.IsDBNull(descriptionIndex)
                                ? null
                                : reader.GetString(descriptionIndex);


                            roles.Add(new RoleDto(
                                reader.GetInt32(roleIDIndex),
                                reader.GetString(roleNameIndex),
                                description,
                                reader.GetDateTime(createdAtIndex),
                                reader.GetBoolean(isActiveIndex),
                                reader.GetString(createdByIndex)
                            ));
                        }
                    }
                }
            }

            return roles;
        }


        public RoleDto? GetRoleByID(int roleID)
        {
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("SP_Role_GetByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    int roleIDIndex = reader.GetOrdinal("RoleID");

                    int roleNameIndex = reader.GetOrdinal("RoleName");
                    int descriptionIndex = reader.GetOrdinal("Description");


                    int createdAtIndex = reader.GetOrdinal("CreatedAt");
                    int isActiveIndex = reader.GetOrdinal("IsActive");
                    int createdByIndex = reader.GetOrdinal("CreatedBy");

                    if (reader.Read())
                    {
                        string? description = reader.IsDBNull(descriptionIndex)
                                ? null
                                : reader.GetString(descriptionIndex);

                        return new RoleDto(
                                reader.GetInt32(roleIDIndex),
                                reader.GetString(roleNameIndex),
                                description,
                                reader.GetDateTime(createdAtIndex),
                                reader.GetBoolean(isActiveIndex),
                                reader.GetString(createdByIndex)
                            );
                    }
                    else
                        return null;
                }
            }
        }


        public bool DeactivateRole(int roleID, string currentUser)
        {
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("SP_Role_Deactivate", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
                command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 100).Value = currentUser;

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }


        public bool ReactivateRole(int roleID, string currentUser)
        {
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("SP_Role_Reactivate", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
                command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 100).Value = currentUser;

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
