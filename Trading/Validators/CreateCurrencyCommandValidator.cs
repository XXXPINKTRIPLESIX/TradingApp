using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.DTO.Request;

namespace Trading.DTO.Validators
{
    public class CreateCurrencyDTOValidator : AbstractValidator<CreateCurrencyDTO>
    {
        public CreateCurrencyDTOValidator()
        {
            RuleFor(c => c.CurrencyCode).NotNull().NotEmpty().WithMessage("CurrencyCode null or empty.");
            RuleFor(c => c.Type).IsInEnum().WithMessage("Incorrect type value.");
        }
    }
}
