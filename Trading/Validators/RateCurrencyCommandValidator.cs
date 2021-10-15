using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.CurrencyCommands;

namespace Trading.Validators
{
    public class RateCurrencyCommandValidator : AbstractValidator<RateCurrencyCommand>
    {
        public RateCurrencyCommandValidator()
        {
            RuleFor(c => c.BaseCurrency).NotEmpty().WithMessage("BaseCurrency is empty.");
        }
    }
}
