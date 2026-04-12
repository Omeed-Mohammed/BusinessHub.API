using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BusinessHub.Contracts.Identity.Requests.RolePermission;


namespace BusinessHub.Validators.Identity.RolePermission
{
    public class RolePermissionRequestValidator : AbstractValidator<RolePermissionRequest>
    {
        public RolePermissionRequestValidator()
        {
            RuleFor(x => x.RoleID)
                .GreaterThan(0).WithMessage("RoleID is required");

            RuleFor(x => x.PermissionID)
                .GreaterThan(0).WithMessage("PermissionID is required");
        }
    }

    public class RemoveRolePermissionRequestValidator : AbstractValidator<RemoveRolePermissionRequest>
    {
        public RemoveRolePermissionRequestValidator()
        {
            RuleFor(x => x.RoleID)
                .GreaterThan(0);

            RuleFor(x => x.PermissionID)
                .GreaterThan(0);
        }
    }


}
