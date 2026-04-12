using BusinessHub.Contracts.Persons.DTOs;
using BusinessHub.Contracts.Persons.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Persons
{
    public static class PersonMapper
    {
        public static PersonDto ToDto(PersonRequestDto p)
        {
            return new PersonDto(
                p.PersonID,
                p.FirstName,
                p.MiddleName,
                p.LastName,
                p.Gender,
                p.BirthDate,
                p.NationalNo,
                p.Address,
                p.Email,
                null,
                string.Empty
            );
        }
    }
}
