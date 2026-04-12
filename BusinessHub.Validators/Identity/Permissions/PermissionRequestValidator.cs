using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BusinessHub.Contracts.Identity.Requests.Permissions;

namespace BusinessHub.Validators.Identity.Permissions
{
    public class PermissionRequestValidator : AbstractValidator<PermissionRequest>
    {
        public PermissionRequestValidator()
        {
            RuleFor(x => x.PermissionName)
                .NotEmpty().WithMessage("PermissionName is required")
                .MaximumLength(100);
        }
    }


}
