using FluentValidation;
using Lern.Core.Models.Users.Settings;

namespace Lern.Core.Validators.Users.Settings
{
    public class ChangePasswordModelValidator : AbstractValidator<ChangePasswordModel>
    {
        public ChangePasswordModelValidator()
        {
            RuleFor(x => x.OldPassword).MinimumLength(8).NotEmpty();
            RuleFor(x => x.NewPassword).MinimumLength(8).NotEmpty();
        }
    }
}