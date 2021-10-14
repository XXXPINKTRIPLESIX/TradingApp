using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.UserCommands;
using Trading.DTO.Request;

namespace Trading.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.Id).NotNull().NotEmpty().WithMessage("Id null or empty.");
            RuleFor(u => u.Password).NotNull().NotEmpty().WithMessage("Password null or empty.");
            RuleFor(u => u.Email).NotNull().NotEmpty().WithMessage("Email null or empty.");
            RuleFor(u => u.Role).NotNull().NotEmpty().WithMessage("Role null or empty.");
        }
    }
}
