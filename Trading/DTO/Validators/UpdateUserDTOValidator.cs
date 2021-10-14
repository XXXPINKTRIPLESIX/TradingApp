using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.DTO.Request;

namespace Trading.DTO.Validators
{
    public class UpdateUserDTOValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserDTOValidator()
        {
            RuleFor(u => u.Id).NotNull().NotEmpty().WithMessage("Id null or empty.");
            RuleFor(u => u.Password).NotNull().NotEmpty().WithMessage("Password null or empty.");
            RuleFor(u => u.Email).NotNull().NotEmpty().WithMessage("Email null or empty.");
            RuleFor(u => u.Role).NotNull().NotEmpty().WithMessage("Role null or empty.");
        }
    }
}
