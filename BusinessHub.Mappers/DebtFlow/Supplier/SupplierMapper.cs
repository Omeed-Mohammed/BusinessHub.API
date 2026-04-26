using BusinessHub.Contracts.DebtFlow.DTOs.Debts;
using BusinessHub.Contracts.DebtFlow.DTOs.Supplier;
using BusinessHub.Contracts.DebtFlow.Requests.Debts;
using BusinessHub.Contracts.DebtFlow.Requests.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Mappers.DebtFlow.Supplier
{
    public static class SupplierMapper
    {
        public static SupplierDto CreateToDebtDto(CreateSupplierRequestDto request)
        {
            return new SupplierDto(
                supplierID: 0, // DB will generate
                fullName: request.FullName!.Trim(),
                phone: request.Phone ?? string.Empty,
                address: request.Address ?? string.Empty,
                note: request.Note ?? string.Empty,
                isActive: true
            );
        }

        public static SupplierDto UpdateToDto(UpdateSupplierRequest request)
        {
            return new SupplierDto(
                supplierID: request.SupplierID,
                fullName: request.FullName.Trim(),
                phone: request.Phone ?? string.Empty,
                address: request.Address ?? string.Empty,
                note: request.Note ?? string.Empty,
                isActive: true
            );
        }
    }
}
