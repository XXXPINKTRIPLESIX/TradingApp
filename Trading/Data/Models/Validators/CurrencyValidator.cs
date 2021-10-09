using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Data.Models.Validators
{
    public class CurrencyValidator : AbstractValidator<Currency>
    {
        public CurrencyValidator()
        {
            RuleFor(c => c.Type).IsInEnum(); 
            RuleFor(c => c.CurrencyCode).NotNull().NotEmpty().WithMessage("Currency code is null or empty.");
        }
    }
}
