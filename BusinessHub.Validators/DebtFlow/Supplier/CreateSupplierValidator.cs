using BusinessHub.Contracts.DebtFlow.Requests.Supplier;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Validators.DebtFlow.Supplier
{
    public class CreateSupplierValidator : AbstractValidator<CreateSupplierRequestDto>
    {
        public CreateSupplierValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("FullName is required")
                .MaximumLength(100);

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required")
                .MaximumLength(50);

            RuleFor(x => x.Address)
                .MaximumLength(50);

            RuleFor(x => x.Note)
                .MaximumLength(250);
        }
    }
}
