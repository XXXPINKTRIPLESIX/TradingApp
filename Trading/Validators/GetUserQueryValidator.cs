using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Queries.UserQueries;

namespace Trading.Validators
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(uq => uq.Id).NotNull().WithMessage("Id is null.");
        }
    }
}
