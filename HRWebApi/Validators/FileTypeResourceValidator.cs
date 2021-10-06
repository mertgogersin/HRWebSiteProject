using FluentValidation;
using HRWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Validators
{
    public class FileTypeResourceValidator : AbstractValidator<FileTypeDTO>
    {
        public FileTypeResourceValidator()
        {
            RuleFor(x => x.FileTypeName)
                .NotEmpty()
                .WithMessage("File type name can't be empty.");
            RuleFor(x => x.FileTypeName)
                .MaximumLength(100)
                .WithMessage("File type name can't be longer than 100");
        }
    }
}
