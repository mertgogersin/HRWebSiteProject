using FluentValidation;
using HRWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Validators
{
    public class AddNotificationResourceValidator : AbstractValidator<AddNotificationDTO>
    {
        public AddNotificationResourceValidator()
        {
            RuleFor(x => x.Description)
                .MaximumLength(200)
                .WithMessage("Description can't be longer than 200");
            RuleFor(x => x.UserID)
                .NotEmpty()
                .WithMessage("User ID can't be empty.");
        }
    }
}
