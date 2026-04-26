using BusinessHub.Contracts.Core.Requests.Company;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Validators.Core.Company
{
    public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyRequest>
    {
        public UpdateCompanyValidator()
        {
            RuleFor(x => x.CompanyID)
                .GreaterThan(0);

            RuleFor(x => x.CompanyName)
                .NotEmpty();

            RuleFor(x => x.Country)
                .NotEmpty();

            RuleFor(x => x.City)
                .NotEmpty();
        }
    }
}
