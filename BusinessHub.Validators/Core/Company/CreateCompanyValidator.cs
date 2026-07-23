using BusinessHub.Contracts.Core.Requests.Company;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Validators.Core.Company
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyRequest>
    {
        public CreateCompanyValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("CompanyName is required");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email))
                .WithMessage("Invalid Email");

            RuleFor(x => x.CompanyName)
                .MaximumLength(200);

            RuleFor(x => x.Country)
                .MaximumLength(100);

            RuleFor(x => x.City)
                .MaximumLength(100);
        }
    }
}
