using FluentValidation;
using HRWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Validators
{
    public class UpcomingBirthdaysResourceValidator : AbstractValidator<UpcomingBirthdaysDTO>
    {
        public UpcomingBirthdaysResourceValidator()
        {
            RuleFor(x => x.FirstName)
                .MaximumLength(50)
                .WithMessage("First name can't be longer than 50");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name can't be empty.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name can't be empty.");
            RuleFor(x => x.LastName)
                .MaximumLength(50)
                .WithMessage("Last name can't be longer than 50");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("Birthdate can't be empty.");
        }
    }
}
