using System.Data;
using FluentValidation;
using Lern.Core.Models.Groups.Users;

namespace Lern.Core.Validators.Groups.Users
{
    public class UserJoinModelValidator : AbstractValidator<UserJoinModel>
    {
        public UserJoinModelValidator()
        {
            RuleFor(x => x.Code).NotEmpty().NotNull().MaximumLength(10);
        }
    }
}