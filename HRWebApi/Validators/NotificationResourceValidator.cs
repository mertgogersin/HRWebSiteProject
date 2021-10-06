using FluentValidation;
using HRWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Validators
{
    public class NotificationResourceValidator : AbstractValidator<NotificationDTO>
    {
        public NotificationResourceValidator()
        {
            RuleFor(x => x.EmployeeName)
                .NotEmpty()
                .WithMessage("Employee name can't be empty.");
            RuleFor(x => x.EmployeeName)
                .MaximumLength(50)
                .WithMessage("Employee name can't be longer than 50.");

            RuleFor(x => x.Description)
                .MaximumLength(200)
                .WithMessage("Notification can't be longer than 200");
        }
    }
}
