using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Queries.UserQueries;

namespace Trading.Validators
{
    public class GetAccountQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetAccountQueryValidator()
        {
            RuleFor(ac => ac.Id).NotNull().WithMessage("Id is null.");
        }
    }
}
