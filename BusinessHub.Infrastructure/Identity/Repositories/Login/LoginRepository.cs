using BusinessHub.Contracts.Identity.DTOs.Login;
using BusinessHub.Contracts.Identity.Interfaces.Login;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Infrastructure.Identity.Repositories.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly string _cs;

        public LoginRepository(IConfiguration config)
        {
            _cs = config.GetConnectionString("DefaultConnection")
                 ?? throw new InvalidOperationException("DefaultConnection was not found.");
        }

        public UserAuthDto GetUserByInfoUsername(string username)
        {
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("SP_User_Login", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    int userIDIndex = reader.GetOrdinal("UserID");
                    int PasswordHashIndex = reader.GetOrdinal("PasswordHash");
                    int isActiveIndex = reader.GetOrdinal("IsActive");


                    if (reader.Read())
                    {
                        return new UserAuthDto(
                            reader.GetInt32(userIDIndex),
                            reader.GetString(PasswordHashIndex),
                            reader.GetBoolean(isActiveIndex)
                        );
                    }
                }
            }

            return null!;
        }

    }
}
