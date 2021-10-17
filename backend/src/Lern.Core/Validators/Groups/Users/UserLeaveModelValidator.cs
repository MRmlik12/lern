using System.Data;
using FluentValidation;
using Lern.Core.Models.Groups.Users;

namespace Lern.Core.Validators.Groups.Users
{
    public class UserLeaveModelValidator : AbstractValidator<UserLeaveModel>
    {
        public UserLeaveModelValidator()
        {
            RuleFor(x => x.GroupId).NotEmpty().NotNull();
        }
    }
}