using BusinessHub.Contracts.Persons.DTOs;
using BusinessHub.Contracts.Persons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Persons.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _repo;

        public PersonService(IPersonRepository repo)
        {
            _repo = repo;
        }

        public int AddPerson(PersonDto person , string currentUser)
        {
            if (person == null)
                throw new ArgumentException("Invalid data");

            if (string.IsNullOrWhiteSpace(person.FirstName))
                throw new ArgumentException("FirstName required");


            return _repo.AddPerson(person, currentUser);
        }

        public  bool UpdatePerson(PersonDto person, string currentUser)
        {
            if (person == null || person.PersonID <= 0)
                throw new ArgumentException("Invalid data");


            return _repo.UpdatePerson(person, currentUser);
        }

        public  List<PersonDto> GetAllPersons()
        {
            var persons = _repo.GetAllPersons();

            return persons ?? new List<PersonDto>();
        }

        public  PersonDto GetPersonById(int personID)
        {
            if (personID <= 0)
                throw new ArgumentException("Invalid PersonID", nameof(personID));

            var person = _repo.GetPersonById(personID);

            if (person == null)
                throw new KeyNotFoundException("Person not found");


            return person;
        }

        public  PersonDto GetByNationalNo(string nationalNo)
        {
            if (string.IsNullOrWhiteSpace(nationalNo))
                throw new ArgumentException("NationalNo required");

            var person = _repo.GetByNationalNo(nationalNo);

            if (person == null)
                throw new KeyNotFoundException("Person not found");

            return person;
        }

        public  List<PersonDto> SearchByLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("LastName required");

            return _repo.SearchByLastName(lastName) ?? new List<PersonDto>();
        }
    }
}
