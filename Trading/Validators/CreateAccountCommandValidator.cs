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
            RuleFor(a => a.CurrencyId).NotNull().NotEmpty().WithMessage("CurrencyId null or empty.");
            RuleFor(a => a.UserId).NotNull().NotEmpty().WithMessage("UserId null or empty.");
        }
    }
}
