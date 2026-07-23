using BusinessHub.Contracts.Projects.Requests.ProjectTask;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Validators.Projects.ProjectTask
{
    public class UpdateProjectTaskValidator : AbstractValidator<UpdateProjectTaskRequestDto>
    {
        public UpdateProjectTaskValidator()
        {
            RuleFor(x => x.TaskID)
                .GreaterThan(0);

            RuleFor(x => x.ProjectID)
                .GreaterThan(0);

            RuleFor(x => x.TaskName)
                .NotEmpty().WithMessage("TaskName is required");

            RuleFor(x => x.StatusID)
                .GreaterThan(0);

            RuleFor(x => x.Weight)
                .GreaterThan(0);

            RuleFor(x => x.ProgressPercent)
                .InclusiveBetween(0, 100);
        }
    }
}
