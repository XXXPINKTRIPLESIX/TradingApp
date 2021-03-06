using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.CurrencyCommands;

namespace Trading.Validators
{
    public class CreateCurrencyCommandValidator : AbstractValidator<CreateCurrencyCommand>
    {
        public CreateCurrencyCommandValidator()
        {
            RuleFor(c => c.CurrencyCode).NotEmpty().WithMessage("CurrencyCode is empty.");
            RuleFor(c => c.Type).IsInEnum().WithMessage("Incorrect type value.");
        }
    }
}
