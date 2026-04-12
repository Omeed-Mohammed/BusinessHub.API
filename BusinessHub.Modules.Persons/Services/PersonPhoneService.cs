using BusinessHub.Contracts.Persons.DTOs;
using BusinessHub.Contracts.Persons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Persons.Services
{
    public class PersonPhoneService
    {
        private readonly IPersonPhoneRepository _repo;

        public PersonPhoneService(IPersonPhoneRepository repo)
        {
            _repo = repo;
        }

        public int AddPersonPhone(PersonPhoneDto personPhone, string currentUser)
        {
            if (personPhone == null || personPhone.PersonID <= 0)
                throw new ArgumentNullException(nameof(personPhone));

            if (string.IsNullOrWhiteSpace(personPhone.PhoneNumber))
                throw new ArgumentException("Phone is required");


            return _repo.AddPersonPhone(personPhone, currentUser);
        }

        public List<PersonPhoneDto> GetPhonesByPersonID(int personID)
        {
            if (personID <= 0)
                throw new ArgumentException("Invalid PersonID");

            return _repo.GetPhonesByPersonID(personID);
        }

        public int RemovePersonPhone(int phoneID, string currentUser)
        {
            if (phoneID <= 0)
                throw new ArgumentException("Invalid PhoneID");

            return _repo.RemovePersonPhone(phoneID, currentUser);
        }
    }
}
