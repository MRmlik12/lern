using FluentValidation;
using Lern.Core.Models.Groups;

namespace Lern.Core.Validators.Groups
{
    public class CreateGroupModelValidator : AbstractValidator<CreateGroupModel>
    {
        public CreateGroupModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(5);
        }
    }
}