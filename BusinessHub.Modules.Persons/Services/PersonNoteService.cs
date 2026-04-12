using BusinessHub.Contracts.Persons.DTOs;
using BusinessHub.Contracts.Persons.Interfaces;
using BusinessHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Persons.Services
{
    public class PersonNoteService
    {
        private readonly IPersonNoteRepository _repo;

        public PersonNoteService(IPersonNoteRepository repo)
        {
            _repo = repo;
        }


        public int AddPersonNote(PersonNoteDto personNote, string currentUser)
        {

            // Validation
            if (personNote == null || personNote.PersonID <= 0)
                throw new ArgumentException("Invalid data");

            if (string.IsNullOrWhiteSpace(personNote.Note))
                throw new ArgumentException("Note is required");


            return _repo.AddPersonNote(personNote, currentUser);
        }


        public List<PersonNoteDto> GetNoteByPersonID(int personID)
        {
            if (personID <= 0)
                throw new ArgumentException("Invalid PersonID");

            return _repo.GetNoteByPersonID(personID);
        }
    }
}
