using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.CurrencyCommands;

namespace Trading.Validators
{
    public class ExchangeFiatCurrencyCommandValidator : AbstractValidator<ExchangeFiatCurrencyCommand>
    {
        public ExchangeFiatCurrencyCommandValidator()
        {
            RuleFor(f => f.AccountId).NotNull().WithMessage("AccountId is null.");
            RuleFor(f => f.TargetAccountId).NotNull().WithMessage("TargetAccountId is null.");
            RuleFor(f => f.Amount).GreaterThan(0).WithMessage("Amount is less or equal than 0.");
        }
    }
}
