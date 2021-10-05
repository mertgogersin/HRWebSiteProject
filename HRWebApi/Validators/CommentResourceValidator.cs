using FluentValidation;
using HRWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Validators
{
    public class CommentResourceValidator : AbstractValidator<CommentDTO>
    {
        public CommentResourceValidator()
        {
            RuleFor(x => x.CommentTitle)
                .NotEmpty()
                .WithMessage("Comment title can not be empty.");
            RuleFor(x => x.CommentTitle)
                .MaximumLength(100)
                .WithMessage("Comment title can't be longer than 100");

            RuleFor(x => x.CommentContent)
               .NotEmpty()
               .WithMessage("Comment content can not be empty.");
            RuleFor(x => x.CommentContent)
                .MaximumLength(1500)
                .WithMessage("Comment content can't be longer than 1500");
        }
    }
}
