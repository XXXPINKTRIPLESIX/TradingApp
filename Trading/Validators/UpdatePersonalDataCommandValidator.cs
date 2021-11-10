using FluentValidation;
using Trading.Commands.UserCommands;

namespace Trading.Validators
{
    public class UpdatePersonalDataCommandValidator : AbstractValidator<UpdatePersonalDataCommand>
    {
        public UpdatePersonalDataCommandValidator()
        {
            RuleFor(pd => pd.UserId).NotEmpty().WithMessage("UserId is null.");
            RuleFor(pd => pd.Name).NotEmpty().WithMessage("Name is empty.");
            RuleFor(pd => pd.LastName).NotEmpty().WithMessage("LastName is empty.");
            RuleFor(pd => pd.Surname).NotEmpty().WithMessage("Surname is empty.");
            RuleFor(pd => pd.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is empty.");
            RuleFor(pd => pd.Description).NotEmpty().WithMessage("Description is empty.");
        }
    }
}