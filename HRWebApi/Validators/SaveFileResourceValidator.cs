using FluentValidation;
using HRWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Validators
{
    public class SaveFileResourceValidator : AbstractValidator<SaveFileDTO>
    {
        public SaveFileResourceValidator()
        {
            RuleFor(x => x.FileName)
                .NotEmpty()
                .WithMessage("File name can't be empty.");
            RuleFor(x => x.FileName)
                .MaximumLength(100)
                .WithMessage("File name can't be longer than 100");
        }
    }
}
