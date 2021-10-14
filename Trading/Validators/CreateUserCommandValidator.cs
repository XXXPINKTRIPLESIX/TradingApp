using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.UserCommands;

namespace Trading.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Login).NotEmpty().WithMessage("Login is empty.");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Password is empty.");
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email is empty.");
            RuleFor(u => u.Role).NotEmpty().WithMessage("Role is empty.");
        }
    }
}
