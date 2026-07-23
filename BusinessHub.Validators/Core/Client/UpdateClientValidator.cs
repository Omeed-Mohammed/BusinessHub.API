using BusinessHub.Contracts.Core.Requests.Client;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Validators.Core.Client
{
    public class UpdateClientValidator : AbstractValidator<UpdateClientRequest>
    {
        public UpdateClientValidator()
        {
            RuleFor(x => x.ClientID)
                .GreaterThan(0);

            RuleFor(x => x.CompanyID)
                .GreaterThan(0);

            RuleFor(x => x.ClientName)
                .NotEmpty();

            RuleFor(x => x.ClientTypeID)
                .GreaterThan(0);
        }
    }
}
