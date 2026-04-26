using BusinessHub.Contracts.Core.Requests.Client;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Validators.Core.Client
{
    public class CreateClientValidator : AbstractValidator<CreateClientRequest>
    {
        public CreateClientValidator()
        {
            RuleFor(x => x.CompanyID)
                .GreaterThan(0);

            RuleFor(x => x.ClientName)
                .NotEmpty().WithMessage("ClientName is required");

            RuleFor(x => x.Email)
                .EmailAddress()
                .When(x => !string.IsNullOrWhiteSpace(x.Email))
                .WithMessage("Invalid Email");
        }
    }
}
