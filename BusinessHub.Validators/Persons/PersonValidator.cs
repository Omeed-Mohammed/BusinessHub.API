using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BusinessHub.Contracts.Persons.Requests;

namespace BusinessHub.Validators.Persons
{
    public class PersonValidator : AbstractValidator<PersonRequestDto>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is required");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required");

            RuleFor(x => x.NationalNo)
                .NotEmpty().WithMessage("NationalNo is required");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("Invalid Email");

            RuleFor(x => x.BirthDate)
                .LessThan(DateTime.Now)
                .When(x => x.BirthDate.HasValue);
        }
    }
}
