using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.DebtFlow.Requests.Debts
{
    public class CreateSupplierDebtRequest
    {
        public int SupplierID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }

        public CreateSupplierDebtRequest(int supplierID, decimal amount, 
            DateTime date, string note, string createdBy)
        {
            SupplierID = supplierID;
            Amount = amount;
            Date = date;
            Note = note;
            CreatedBy = createdBy;
        }
    }
}
