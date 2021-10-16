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
            RuleFor(cc => cc.BaseCurrency).NotEmpty().WithMessage("BaseCurrency is empty.");
            RuleFor(cc => cc.TargetCurrency).NotEmpty().WithMessage("TargetCurrency is empty.");
            RuleFor(cc => cc.Amount).GreaterThan(0).WithMessage("Amount is less or equal than 0.");
        }
    }
}
