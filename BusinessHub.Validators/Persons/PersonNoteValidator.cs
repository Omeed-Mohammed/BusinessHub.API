using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BusinessHub.Contracts.Persons.Requests;

namespace BusinessHub.Validators.Persons
{
    public class PersonNoteValidator : AbstractValidator<PersonNoteRequestDto>
    {
        public PersonNoteValidator()
        {
            RuleFor(x => x.PersonID)
                .GreaterThan(0).WithMessage("PersonID is required");

            RuleFor(x => x.Note)
                .NotEmpty().WithMessage("Note is required")
                .MaximumLength(500).WithMessage("Note is too long");
        }
    }
}
