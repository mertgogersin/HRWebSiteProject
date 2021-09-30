using FluentValidation;
using HRWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Validators
{
    public class UserResourceValidator : AbstractValidator<UserDTO>
    {
        public UserResourceValidator()
        {
            RuleFor(x => x.UserID)
                .NotEmpty()
                .WithMessage("User ID can not be empty.");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name can't be empty.");
            RuleFor(x => x.FirstName)
                .MaximumLength(50)
                .WithMessage("First name can't be longer than 50");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name can't be empty.");
            RuleFor(x => x.FirstName)
                .MaximumLength(50)
                .WithMessage("Last name can't be longer than 50");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("E-mail can't be empty.");

            RuleFor(x => x.CompanyID)
                .NotEmpty()
                .WithMessage("Company ID can not be empty.");

        }
    }
}
