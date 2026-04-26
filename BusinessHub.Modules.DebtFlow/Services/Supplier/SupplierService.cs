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

        public SupplierDto GetSupplierById(int supplierId)
        {
            SupplierDto supplierDTO = _repo.GetSupplierById(supplierId);

            return supplierDTO;
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

            var existingSupplier = _repo.GetSupplierById(dto.SupplierID);
            if (existingSupplier == null)
                return false;

            return _repo.UpdateSupplier(dto);
        }

        public bool DeactivateSupplier(int supplierId)
        {
            if (supplierId <= 0)
                return false;

            return _repo.DeactivateSupplier(supplierId);

        }

        public bool ReactivateSupplier(int supplierId)
        {
            if (supplierId <= 0)
                return false;

            return _repo.ReactivateSupplier(supplierId);
        }
    }
}
