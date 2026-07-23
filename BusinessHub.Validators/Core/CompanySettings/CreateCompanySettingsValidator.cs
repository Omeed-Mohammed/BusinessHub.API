using BusinessHub.Contracts.Core.Requests.CompanySettings;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Validators.Core.CompanySettings
{
    public class CreateCompanySettingsValidator : AbstractValidator<CreateCompanySettingsRequest>
    {
        public CreateCompanySettingsValidator()
        {
            RuleFor(x => x.CompanyID)
                .GreaterThan(0);

            RuleFor(x => x.CurrencyCode)
                .NotEmpty().WithMessage("CurrencyCode is required");

            RuleFor(x => x.TaxRate)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.CurrencyCode)
                .Length(3);
        }
    }
}
