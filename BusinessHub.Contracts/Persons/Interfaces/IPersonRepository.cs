using BusinessHub.Contracts.Persons.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Persons.Interfaces
{
    public interface IPersonRepository
    {
        int AddPerson(PersonDto person, string currentUser);
        bool UpdatePerson(PersonDto person, string currentUser);
        List<PersonDto> GetAllPersons();
        PersonDto GetPersonById(int personId);
        PersonDto GetByNationalNo(string nationalNo);
        List<PersonDto> SearchByLastName(string lastName);
    }
}
