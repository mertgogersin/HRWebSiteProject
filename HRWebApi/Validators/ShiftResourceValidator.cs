using FluentValidation;
using HRWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Validators
{
    public class ShiftResourceValidator : AbstractValidator<ShiftDTO>
    {
        public ShiftResourceValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Full name can't be empty.");
            RuleFor(x => x.FullName)
                .MaximumLength(101)
                .WithMessage("Full name can't be longer than 100");
        }
    }
}
