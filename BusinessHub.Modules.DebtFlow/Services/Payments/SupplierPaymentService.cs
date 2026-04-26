using BusinessHub.Contracts.DebtFlow.DTOs.Payments;
using BusinessHub.Contracts.DebtFlow.Interfaces;
using BusinessHub.Contracts.Persons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.DebtFlow.Services.Payments
{
    public class SupplierPaymentService
    {
        private readonly ISupplierPaymentRepository _repo;

        public SupplierPaymentService(ISupplierPaymentRepository repo)
        {
            _repo = repo;
        }

        public string AddSupplierPayment(CreateSupplierPaymentTransactionRequestDto RequestDTO)
        {
            if (RequestDTO.SupplierID <= 0 ||
                RequestDTO.InvoiceAmount <= 0 ||
                string.IsNullOrWhiteSpace(RequestDTO.ReceiverName) ||
                string.IsNullOrWhiteSpace(RequestDTO.CreatedBy))
                throw new ArgumentException("Invalid payment request.");


            return _repo.AddSupplierPayment(RequestDTO);
        }


        public List<SupplierPaymentViewDto> GetPaymentsBySupplierID(int supplierID)
        {
            if (supplierID <= 0)
                return new List<SupplierPaymentViewDto>();

            return _repo.GetPaymentsBySupplierID(supplierID);
        }


        public bool UpdateSupplierPayments(UpdateSupplierPaymentRequestDto paymentDTO)
        {
            if (paymentDTO.PaymentID <= 0 ||
                string.IsNullOrWhiteSpace(paymentDTO.UpdatedBy))
                return false;

            return _repo.UpdateSupplierPayments(paymentDTO);
        }
    }
}
