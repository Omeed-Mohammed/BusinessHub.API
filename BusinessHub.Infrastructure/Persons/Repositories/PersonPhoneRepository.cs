using BusinessHub.Contracts.Persons.DTOs;
using BusinessHub.Contracts.Persons.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Infrastructure.Persons.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly string _cs ;

        public PersonPhoneRepository(IConfiguration config)
        {
            _cs = config.GetConnectionString("DefaultConnection")!;
        }


        public int AddPersonPhone(PersonPhoneDto personPhone, string currentUser)
        {
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("SP_PersonPhone_Add", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", personPhone.PersonID);

                command.Parameters.AddWithValue("@PhoneNumber", personPhone.PhoneNumber);

                command.Parameters.AddWithValue("@CurrentUser", currentUser);


                connection.Open();
                var result = command.ExecuteScalar();

                return Convert.ToInt32(result);
            }
        }

        public List<PersonPhoneDto> GetPhonesByPersonID(int personID)
        {
            var personPhones = new List<PersonPhoneDto>();

            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("SP_PersonPhone_GetByPersonID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", personID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int phoneIDIndex = reader.GetOrdinal("PhoneID");
                    int personIDIndex = reader.GetOrdinal("PersonID");

                    int phoneNumberIndex = reader.GetOrdinal("PhoneNumber");

                    int CreatedAtIndex = reader.GetOrdinal("CreatedAt");

                    while (reader.Read())
                    {

                        personPhones.Add(new PersonPhoneDto(
                                reader.GetInt32(phoneIDIndex),
                                personID,
                                reader.GetString(phoneNumberIndex),
                                reader.GetDateTime(CreatedAtIndex)
                            ));
                    }

                }
            }

            return personPhones;
        }

        public int RemovePersonPhone(int phoneID, string currentUser)
        {
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("SP_PersonPhone_Remove", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PhoneID", phoneID);
                command.Parameters.AddWithValue("@CurrentUser", currentUser);

                connection.Open();

                var result = command.ExecuteScalar();

                return Convert.ToInt32(result);
            }
        }
    }
}
