using BusinessHub.Contracts.Persons.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Persons.Interfaces
{
    public interface IPersonPhoneRepository
    {
        int AddPersonPhone(PersonPhoneDto personPhone, string currentUser);
        List<PersonPhoneDto> GetPhonesByPersonID(int personID);
        int RemovePersonPhone(int phoneID, string currentUser);
    }
}
