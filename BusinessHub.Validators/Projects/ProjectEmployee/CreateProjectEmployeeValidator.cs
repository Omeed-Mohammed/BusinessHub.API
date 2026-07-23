using BusinessHub.Contracts.Projects.Requests.ProjectEmployee;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Validators.Projects.ProjectEmployee
{
    public class CreateProjectEmployeeValidator : AbstractValidator<CreateProjectEmployeeRequestDto>
    {
        public CreateProjectEmployeeValidator()
        {
            RuleFor(x => x.ProjectID)
                .GreaterThan(0);

            RuleFor(x => x.EmployeeID)
                .GreaterThan(0);

            RuleFor(x => x.StartDate)
                .NotEmpty();
        }
    }
}
