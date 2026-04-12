using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BusinessHub.Contracts.Persons.Requests;

namespace BusinessHub.Validators.Persons
{
    public class PersonPhoneValidator : AbstractValidator<PersonPhoneRequestDto>
    {
        public PersonPhoneValidator()
        {
            RuleFor(x => x.PersonID)
                .GreaterThan(0).WithMessage("PersonID is required");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber is required")
                .Matches(@"^\+?\d{7,15}$")
                .WithMessage("Invalid phone format");
        }
    }
}
