using BusinessHub.Contracts.DebtFlow.DTOs.Debts;
using BusinessHub.Contracts.DebtFlow.Requests.Debts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.DebtFlow.Debts
{
    public class SupplierDebtMapper
    {
        public static SupplierDebtDto CreateToDebtDto(CreateSupplierDebtRequest request)
        {
            return new SupplierDebtDto(
                debtID: 0, // DB
                supplierID: request.SupplierID,
                amount: request.Amount,
                date: request.Date,
                note: request.Note ?? string.Empty,
                createdBy: request.CreatedBy,
                createdAt: null,
                updatedBy: null!,
                updatedAt: null
            );
        }

        public static SupplierDebtDto UpdateToDebtDto(UpdateSupplierDebtRequest request, SupplierDebtDto existing)
        {
            return new SupplierDebtDto(
                debtID: existing.DebtID,
                supplierID: existing.SupplierID, // لا يتغير
                amount: request.Amount,
                date: request.Date,
                note: request.Note ?? string.Empty,
                createdBy: existing.CreatedBy,   // محفوظ
                createdAt: existing.CreatedAt,   // محفوظ
                updatedBy: request.UpdatedBy,
                updatedAt: null // DB
            );
        }
    }
}
