using BusinessHub.Contracts.DebtFlow.DTOs.Supplier;
using BusinessHub.Contracts.DebtFlow.Interfaces;
using BusinessHub.Contracts.DebtFlow.Requests.Supplier;
using BusinessHub.Contracts.Persons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.DebtFlow.Services.Supplier
{
    public class SupplierService
    {
        private readonly ISupplierRepository _repo;

        public SupplierService(ISupplierRepository repo)
        {
            _repo = repo;
        }

        public List<SupplierDto> GetAllSuppliers(bool? isActive = true)
        {
            return _repo.GetAllSuppliers(isActive);
        }

        public SupplierDto? GetSupplierById(int supplierId)
        {
            return _repo.GetSupplierById(supplierId);
        }

        public int AddSupplier(SupplierDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName) ||
                string.IsNullOrWhiteSpace(dto.Phone))
                return -1;

            return _repo.AddSupplier(dto);
        }

        public bool UpdateSupplier(SupplierDto dto)
        {
            if (dto.SupplierID <= 0 ||
                string.IsNullOrWhiteSpace(dto.FullName) ||
                string.IsNullOrWhiteSpace(dto.Phone))
                return false;

            SupplierDto? existingSupplier = _repo.GetSupplierById(dto.SupplierID);

            if (existingSupplier is null)
                return false;

            return _repo.UpdateSupplier(dto);
        }

        public bool DeactivateSupplier(int supplierId, string currentUser)
        {
            if (supplierId <= 0)
                return false;

            return _repo.DeactivateSupplier(supplierId, currentUser);
        }

        public bool ReactivateSupplier(int supplierId, string currentUser)
        {
            if (supplierId <= 0)
                return false;

            return _repo.ReactivateSupplier(supplierId, currentUser);
        }
    }
}
