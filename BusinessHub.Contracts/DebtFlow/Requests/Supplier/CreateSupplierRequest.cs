using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.DebtFlow.Requests.Supplier
{
    public class CreateSupplierRequestDto
    {
        public int CompanyID { get; set; }

        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Note { get; set; }


        public CreateSupplierRequestDto(
        string? fullName,
        string? phone,
        string? address,
        string? note)
        {
            FullName = fullName;
            Phone = phone;
            Address = address;
            Note = note;
        }

    }
}
