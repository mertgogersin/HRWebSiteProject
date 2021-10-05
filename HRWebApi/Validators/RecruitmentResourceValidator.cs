using FluentValidation;
using HRWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Validators
{
    public class RecruitmentResourceValidator : AbstractValidator<RecruitmentDTO>
    {
        public RecruitmentResourceValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name can't be empty.");
            RuleFor(x => x.FirstName)
              .MaximumLength(50)
              .WithMessage("First name can't be longer than 50.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name can't be empty.");
            RuleFor(x => x.LastName)
                .MaximumLength(50)
                .WithMessage("Last name can't be longer than 50.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("E-mail can't be empty.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number can not be empty.");

            RuleFor(x => x.StartingDate)
                .NotEmpty()
                .WithMessage("Starting date can not be empty.");
        }
    }
}
