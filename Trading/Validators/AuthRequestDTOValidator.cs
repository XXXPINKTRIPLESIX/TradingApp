using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.DTO.Request;

namespace Trading.DTO.Validators
{
    public class AuthRequestDTOValidator : AbstractValidator<AuthDTO>
    {
        public AuthRequestDTOValidator()
        {
            RuleFor(a => a.Login).NotNull().NotEmpty().WithMessage("Login null or empty.");
            RuleFor(a => a.Password).NotNull().NotEmpty().WithMessage("Password null or empty.");
        }
    }
}
