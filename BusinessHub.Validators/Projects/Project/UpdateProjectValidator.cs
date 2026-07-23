using BusinessHub.Contracts.Projects.Requests.Project;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Validators.Projects.Project
{
    public class UpdateProjectValidator : AbstractValidator<UpdateProjectRequestDto>
    {
        public UpdateProjectValidator()
        {
            RuleFor(x => x.ProjectID)
                .GreaterThan(0);

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
