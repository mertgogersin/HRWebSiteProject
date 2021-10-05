using FluentValidation;
using HRWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Validators
{
    public class ExpenseResourceValidator : AbstractValidator<ExpenseDTO>
    {
        public ExpenseResourceValidator()
        {
            RuleFor(x => x.TotalPrice)
                .NotEmpty()
                .WithMessage("Total price can't be empty.");
            RuleFor(x => x.Description)
                .MaximumLength(200)
                .WithMessage("Description can't be longer than 200.");
        }
    }
}
