using BusinessHub.Contracts.Projects.Requests.Project;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Validators.Projects.Project
{
    public class CreateProjectValidator : AbstractValidator<CreateProjectRequestDto>
    {
        public CreateProjectValidator()
        {
            RuleFor(x => x.BranchID)
                .GreaterThan(0);

            RuleFor(x => x.ProjectName)
                .NotEmpty().WithMessage("ProjectName is required");

            RuleFor(x => x.StartDate)
                .NotEmpty();

            RuleFor(x => x.StatusID)
                .GreaterThan(0);
        }
    }
}
