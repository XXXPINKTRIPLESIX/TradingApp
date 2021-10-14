using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.AuthCommands;
using Trading.DTO.Request;

namespace Trading.Validators
{
    public class GetTokenCommandValidator : AbstractValidator<GetTokenCommand>
    {
        public GetTokenCommandValidator()
        {
            RuleFor(a => a.Login).NotNull().NotEmpty().WithMessage("Login null or empty.");
            RuleFor(a => a.Password).NotNull().NotEmpty().WithMessage("Password null or empty.");
        }
    }
}
