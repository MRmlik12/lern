using FluentValidation;
using Lern.Core.Models.Users.Settings;

namespace Lern.Core.Validators.Users.Settings
{
    public class ChangeUsernameModelValidator : AbstractValidator<ChangeUsernameModel>
    {
        public ChangeUsernameModelValidator()
        {
            RuleFor(e => e.NewUsername).MinimumLength(4).NotEmpty();
        }
    }
}