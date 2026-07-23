using BusinessHub.Contracts.Core.Requests.Branch;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Validators.Core.Branch
{
    public class CreateBranchValidator : AbstractValidator<CreateBranchRequest>
    {
        public CreateBranchValidator()
        {
            RuleFor(x => x.CompanyID)
                .GreaterThan(0);

            RuleFor(x => x.BranchName)
                .NotEmpty().WithMessage("BranchName is required");

            RuleFor(x => x.BranchName)
                .MaximumLength(200);
        }
    }
}
