using BusinessHub.Contracts.DebtFlow.DTOs.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.DebtFlow.Interfaces
{
    public interface ISupplierInvoicesRepository
    {
        SupplierPaymentInvoiceDto GetInvoiceByReceiptNo(string receiptNo);
    }
}
