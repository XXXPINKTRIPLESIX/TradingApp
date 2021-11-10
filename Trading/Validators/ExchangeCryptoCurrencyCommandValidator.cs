using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.CurrencyCommands;

namespace Trading.Validators
{
    public class ExchangeCryptoCurrencyCommandValidator : AbstractValidator<ExchangeCryptoCurrencyCommand>
    {
        public ExchangeCryptoCurrencyCommandValidator()
        {
            RuleFor(cc => cc.AccountId).NotNull().WithMessage("AccountId is null.");
            RuleFor(cc => cc.TargetAccountId).NotNull().WithMessage("TargetAccountId is null.");
            RuleFor(cc => cc.Amount).GreaterThan(0).WithMessage("Amount is less or equal than 0.");
        }
    }
}
