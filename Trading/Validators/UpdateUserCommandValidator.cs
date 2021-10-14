using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.UserCommands;

namespace Trading.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.Id).NotNull().WithMessage("Id is null.");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Password is empty.");
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email is empty.");
            RuleFor(u => u.Role).NotEmpty().WithMessage("Role is empty.");
        }
    }
}
