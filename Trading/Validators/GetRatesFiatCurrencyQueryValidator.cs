using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Queries.CurrencyQueries;

namespace Trading.Validators
{
    public class GetRatesFiatCurrencyQueryValidator : AbstractValidator<GetRatesFiatCurrencyQuery>
    {
        public GetRatesFiatCurrencyQueryValidator()
        {
            RuleFor(c => c.BaseCurrency).NotEmpty().WithMessage("BaseCurrency is empty.");
        }
    }
}
