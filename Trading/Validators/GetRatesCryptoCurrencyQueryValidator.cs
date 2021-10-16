using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Queries.CurrencyQueries;

namespace Trading.Validators
{
    public class GetRatesCryptoCurrencyQueryValidator : AbstractValidator<GetRatesCryptoCurrencyQuery>
    {
        public GetRatesCryptoCurrencyQueryValidator()
        {
            RuleFor(cc => cc.BaseCurrency).NotEmpty().WithMessage("BaseCurrency is empty.");
        }
    }
}
