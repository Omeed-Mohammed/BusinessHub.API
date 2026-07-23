using BusinessHub.Contracts.Core.Requests.Branch;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Validators.Core.Branch
{
    public class UpdateBranchValidator : AbstractValidator<UpdateBranchRequest>
    {
        public UpdateBranchValidator()
        {
            RuleFor(x => x.BranchID)
                .GreaterThan(0);

            RuleFor(x => x.CompanyID)
                .GreaterThan(0);

            RuleFor(x => x.BranchName)
                .NotEmpty();

            RuleFor(x => x.BranchName)
                .MaximumLength(200);
        }
    }
}
