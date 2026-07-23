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
        public static SupplierDto CreateToDto(
            CreateSupplierRequestDto request,
            int companyID,
            string currentUser)
        {
            return new SupplierDto(
                supplierID: 0,
                companyID: companyID,
                fullName: request.FullName!.Trim(),
                phone: request.Phone ?? string.Empty,
                address: request.Address,
                note: request.Note,
                isActive: true,
                createdBy: currentUser,
                createdAt: DateTime.UtcNow,
                updatedBy: null,
                updatedAt: null
            );
        }

        public static SupplierDto UpdateToDto(
            UpdateSupplierRequestDto request,
            string currentUser)
        {
            return new SupplierDto(
                supplierID: request.SupplierID,
                companyID: 0,
                fullName: request.FullName!.Trim(),
                phone: request.Phone ?? string.Empty,
                address: request.Address,
                note: request.Note,
                isActive: true,
                createdBy: string.Empty,
                createdAt: DateTime.MinValue,
                updatedBy: currentUser,
                updatedAt: DateTime.UtcNow
            );
        }
    }
}
