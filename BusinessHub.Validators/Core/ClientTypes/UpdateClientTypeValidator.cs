using BusinessHub.Contracts.Core.Requests.ClientTypes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Validators.Core.ClientTypes
{
    public class UpdateClientTypeValidator : AbstractValidator<UpdateClientTypeRequest>
    {
        public UpdateClientTypeValidator()
        {
            RuleFor(x => x.ClientTypeID)
                .GreaterThan(0);

            RuleFor(x => x.ClientTypeName)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
