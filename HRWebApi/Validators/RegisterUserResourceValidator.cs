using FluentValidation;
using HRWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Validators
{
    public class RegisterUserResourceValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterUserResourceValidator()
        {
            RuleFor(m => m.FirstName)
                .MaximumLength(50)
                .WithMessage("First name can't longer than 50 chars.");
            RuleFor(m => m.FirstName).NotEmpty().WithMessage("First name can't be empty");

            RuleFor(m => m.LastName)
                .MaximumLength(50)
                .WithMessage("Last name can't longer than 50 chars.");
            RuleFor(m => m.LastName).NotEmpty().WithMessage("Last name can't be empty");

            RuleFor(m => m.CompanyName)
                .NotEmpty()
                .WithMessage("Company Name can't be null.");
        }
    }
}
