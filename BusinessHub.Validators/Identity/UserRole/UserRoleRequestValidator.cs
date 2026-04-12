using BusinessHub.Contracts.Identity.Requests.UserRole;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Validators.Identity.UserRole
{
    public class UserRoleRequestValidator : AbstractValidator<UserRoleRequest>
    {
        public UserRoleRequestValidator()
        {
            RuleFor(x => x.UserID)
                .GreaterThan(0);

            RuleFor(x => x.RoleID)
                .GreaterThan(0);
        }
    }
}
