using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Data.Models.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Login).NotNull().NotEmpty().WithMessage("Login is null.");
            RuleFor(u => u.Password).NotNull().NotEmpty().WithMessage("Password is null.");
            RuleFor(u => u.Email).NotNull().NotEmpty().WithMessage("Password is null.").EmailAddress().WithMessage("Email is not valid.");
        }
    }
}
