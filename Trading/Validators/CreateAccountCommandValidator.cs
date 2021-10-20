using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.AccountCommands;

namespace Trading.Validators
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(a => a.CurrencyId).NotNull().WithMessage("CurrencyId is null.");
            RuleFor(a => a.UserId).NotNull().WithMessage("UserId is null.");
        }
    }
}
