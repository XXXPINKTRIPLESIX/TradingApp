using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Queries.CurrencyQueries;

namespace Trading.Validators
{
    public class GetCurrencyQueryValidator : AbstractValidator<GetCurrencyQuery>
    {
        public GetCurrencyQueryValidator()
        {
            RuleFor(cq => cq.Id).NotNull().WithMessage("Id is null.");
        }
    }
}
