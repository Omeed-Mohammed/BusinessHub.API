using BusinessHub.Contracts.DebtFlow.DTOs.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.DebtFlow.Interfaces
{
    public interface ISupplierPaymentRepository
    {
        string AddSupplierPayment(CreateSupplierPaymentTransactionRequestDto RequestDTO);
        List<SupplierPaymentViewDto> GetPaymentsBySupplierID(int supplierID);
        bool UpdateSupplierPayments(UpdateSupplierPaymentRequestDto paymentDTO);
    }
}
