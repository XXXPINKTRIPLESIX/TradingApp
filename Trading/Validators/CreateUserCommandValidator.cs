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
            RuleFor(u => u.Login).NotNull().NotEmpty().WithMessage("Login null or empty.");
            RuleFor(u => u.Password).NotNull().NotEmpty().WithMessage("Password null or empty.");
            RuleFor(u => u.Email).NotNull().NotEmpty().WithMessage("Email null or empty.");
            RuleFor(u => u.Role).NotNull().NotEmpty().WithMessage("Role null or empty.");
        }
    }
}
