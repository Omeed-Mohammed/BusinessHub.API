using BusinessHub.Contracts.DebtFlow.DTOs.Invoices;
using BusinessHub.Contracts.DebtFlow.Interfaces;
using BusinessHub.Contracts.Persons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.DebtFlow.Services.Invoices
{
    public class SupplierInvoiceService
    {
        private readonly ISupplierInvoicesRepository _repo;

        public SupplierInvoiceService(ISupplierInvoicesRepository repo)
        {
            _repo = repo;
        }

        public SupplierPaymentInvoiceDto GetInvoiceByReceiptNo(string receiptNo)
        {
            if (string.IsNullOrEmpty(receiptNo))
                throw new ArgumentNullException(nameof(receiptNo));

            return _repo.GetInvoiceByReceiptNo(receiptNo);
        }
    }
}
