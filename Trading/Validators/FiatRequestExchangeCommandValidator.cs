using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.CurrencyCommands;
using Trading.DTO.Request;

namespace Trading.Validators
{
    public class FiatRequestExchangeCommandValidator : AbstractValidator<ExchangeCurrencyCommand>
    {
        public FiatRequestExchangeCommandValidator()
        {
            RuleFor(f => f.TargetCurrency).NotEmpty().WithMessage("Target currency is empty.");
            RuleFor(f => f.BaseCurrency).NotEmpty().WithMessage("Base currency is empty.");
            RuleFor(f => f.Amount).GreaterThan(0).WithMessage("Amount is less or equal 0.");
        }
    }
}
