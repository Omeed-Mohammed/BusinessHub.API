using BusinessHub.Contracts.Persons.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Persons.Interfaces
{
    public interface IPersonNoteRepository
    {
        int AddPersonNote(PersonNoteDto personNote, string currentUser);
        List<PersonNoteDto> GetNoteByPersonID(int personID);
    }
}
