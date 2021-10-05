using FluentValidation;
using HRWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Validators
{
    public class DebitResourceValidator : AbstractValidator<DebitDTO>
    {
        public DebitResourceValidator()
        {
            RuleFor(x => x.UserID)
               .NotEmpty()
               .WithMessage("User ID can not be empty.");

            RuleFor(x => x.ProductName)
                .NotEmpty()
                .WithMessage("Product name can't be empty.");

            RuleFor(x => x.Description)
                .MaximumLength(200)
                .WithMessage("Description can't be longer than 200");
        }
    }
}
