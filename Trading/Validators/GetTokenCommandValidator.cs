using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.AuthCommands;

namespace Trading.Validators
{
    public class GetTokenCommandValidator : AbstractValidator<GetTokenCommand>
    {
        public GetTokenCommandValidator()
        {
            RuleFor(a => a.Login).NotEmpty().WithMessage("Login is empty.");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Password is empty.");
        }
    }
}
