using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.CurrencyCommands;

namespace Trading.Validators
{
    public class ExchangeCommandValidator : AbstractValidator<ExchangeCurrencyCommand>
    {
        public ExchangeCommandValidator()
        {
            RuleFor(f => f.TargetCurrency).NotEmpty().WithMessage("TargetCurrency is empty.");
            RuleFor(f => f.BaseCurrency).NotEmpty().WithMessage("BaseCurrency is empty.");
            RuleFor(f => f.Amount).GreaterThan(0).WithMessage("Amount is less or equal than 0.");
        }
    }
}
