using BusinessHub.Contracts.DebtFlow.DTOs.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.DebtFlow.Interfaces
{
    public interface ISupplierRepository
    {
        List<SupplierDto> GetAllSuppliers(bool? isActive = true);
        SupplierDto? GetSupplierById(int supplierId);
        int AddSupplier(SupplierDto supplier);
        bool UpdateSupplier(SupplierDto supplier);
        bool DeactivateSupplier(int supplierId , string currentUser);
        bool ReactivateSupplier(int supplierId , string currentUser);
    }
}
