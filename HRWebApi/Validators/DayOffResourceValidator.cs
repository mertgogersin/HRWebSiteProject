using FluentValidation;
using HRWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Validators
{
    public class DayOffResourceValidator : AbstractValidator<DayOffDTO>
    {
        public DayOffResourceValidator()
        {
            RuleFor(x => x.Title)
               .MaximumLength(150)
               .WithMessage("Title can't longer than 150 chars.");
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title can't be empty");

            RuleFor(x => x.TypeName)
              .MaximumLength(150)
              .WithMessage("Type name can't longer than 150 chars.");
            RuleFor(x => x.TypeName)
                .NotEmpty()
                .WithMessage("Type name can't be empty");

            RuleFor(x => x.Description)
                .MaximumLength(200)
                .WithMessage("Description can't longer than 200 chars.");

        }
    }
}
