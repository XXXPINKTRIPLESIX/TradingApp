using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Data.Models.Validators
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(a => a.CurrencyId).NotNull().NotEmpty().WithMessage("Currency id is null or empty.").GreaterThan(0).WithMessage("Currency id must be greater than 0.");
            RuleFor(a => a.Currency).NotNull();
        }
    }
}
