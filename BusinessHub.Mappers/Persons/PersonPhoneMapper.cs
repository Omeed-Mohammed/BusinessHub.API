using BusinessHub.Contracts.Persons.Requests;
using BusinessHub.Contracts.Persons.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Persons
{
    public static class PersonPhoneMapper
    {
        public static PersonPhoneDto ToDto(PersonPhoneRequestDto p)
        {
            return new PersonPhoneDto(
                p.PhoneID,
                p.PersonID,
                p.PhoneNumber,
                null
            );
        }
    }
}
