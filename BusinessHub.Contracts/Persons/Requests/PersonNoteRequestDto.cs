using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Persons.Requests
{
    public class PersonNoteRequestDto
    {
        public int NoteID { get; set; }
        public int PersonID { get; set; }

        public string Note { get; set; }

        public PersonNoteRequestDto(int noteID, int personID, string note)
        {
            NoteID = noteID;
            PersonID = personID;
            Note = note;
            
        }
    }
}
