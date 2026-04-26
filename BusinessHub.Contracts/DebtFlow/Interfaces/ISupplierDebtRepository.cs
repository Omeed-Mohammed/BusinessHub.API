using BusinessHub.Contracts.DebtFlow.DTOs.Debts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.DebtFlow.Interfaces
{
    public interface ISupplierDebtRepository
    {
        SupplierDebtDto GetDebtById(int debtId);
        List<SupplierDebtDto> GetDebtsBySupplierID(int supplierId);
        int AddDebt(SupplierDebtDto debt);
        bool UpdateDebt(SupplierDebtDto debt);

    }
}
