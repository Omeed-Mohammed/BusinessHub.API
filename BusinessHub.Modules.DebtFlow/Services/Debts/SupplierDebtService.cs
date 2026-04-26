using BusinessHub.Contracts.DebtFlow.DTOs.Debts;
using BusinessHub.Contracts.DebtFlow.Interfaces;
using BusinessHub.Contracts.DebtFlow.Requests.Debts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.DebtFlow.Services.Debts
{
    public class SupplierDebtService
    {
        private readonly ISupplierDebtRepository _repo;

        public SupplierDebtService(ISupplierDebtRepository repo)
        {
            _repo = repo;
        }

        public SupplierDebtDto GetDebtById(int debtId)
        {
            if (debtId <= 0)
                return null!;

            return _repo.GetDebtById(debtId);
        }

        public List<SupplierDebtDto> GetDebtsBySupplierID(int supplierId)
        {
            if (supplierId <= 0)
                return new List<SupplierDebtDto>();

            return _repo.GetDebtsBySupplierID(supplierId);
        }


        public int AddDebt(SupplierDebtDto Dto)
        {
            if (Dto.SupplierID <= 0 ||
                Dto.Amount <= 0 ||
                string.IsNullOrWhiteSpace(Dto.CreatedBy))
                return -1;


            return _repo.AddDebt(Dto);
        }


        public bool UpdateDebt(SupplierDebtDto Dto)
        {
            if (Dto.DebtID <= 0 ||
                Dto.Amount <= 0 ||
                string.IsNullOrWhiteSpace(Dto.UpdatedBy))
                return false;

            var existing = _repo.GetDebtById(Dto.DebtID);
            if (existing == null)
                return false;

            return _repo.UpdateDebt(Dto);
        }
    }
}
