using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Persons.Requests
{
    public class PersonPhoneRequestDto
    {
        public int PhoneID { get; set; }
        public int PersonID { get; set; }
        public string PhoneNumber { get; set; }

        public PersonPhoneRequestDto(int phoneID, int personID, string phoneNumber)
        {
            PhoneID = phoneID;
            PersonID = personID;
            PhoneNumber = phoneNumber;
        }
    }
}
