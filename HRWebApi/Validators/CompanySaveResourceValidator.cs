using FluentValidation;
using HRWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Validators
{
    public class CompanySaveResourceValidator : AbstractValidator<CompanySaveDTO>
    {
        public CompanySaveResourceValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .WithMessage("Company name can not be empty.");
            RuleFor(x => x.CompanyName)
                .MaximumLength(100)
                .WithMessage("Company name can't be longer than 100");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Description can't be longer than 500");

            RuleFor(x => x.Address)
                .MaximumLength(500)
                .WithMessage("Address can't be longer than 500");


        }
    }
}
