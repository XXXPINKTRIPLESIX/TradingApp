using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.DTO.Request;

namespace Trading.DTO.Validators
{
    public class CreateAccountDTOValidator : AbstractValidator<CreateAccountDTO>
    {
        public CreateAccountDTOValidator()
        {
            RuleFor(a => a.CurrencyId).NotNull().NotEmpty().WithMessage("CurrencyId null or empty.");
            RuleFor(a => a.UserId).NotNull().NotEmpty().WithMessage("UserId null or empty.");
        }
    }
}
