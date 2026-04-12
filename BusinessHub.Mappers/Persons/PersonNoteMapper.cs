using BusinessHub.Contracts.Persons.Requests;
using BusinessHub.Contracts.Persons.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.Persons
{
    public class PersonNoteMapper
    {
        public static PersonNoteDto ToDto(PersonNoteRequestDto p)
        {
            return new PersonNoteDto(
                p.NoteID,
                p.PersonID,
                p.Note,
                string.Empty,
                null
            );
        }
    }
}
