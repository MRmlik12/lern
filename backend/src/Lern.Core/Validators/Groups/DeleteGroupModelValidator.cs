using FluentValidation;
using Lern.Core.Models.Groups;

namespace Lern.Core.Validators.Groups
{
    public class DeleteGroupModelValidator : AbstractValidator<DeleteGroupModel>
    {
        public DeleteGroupModelValidator()
        {
            RuleFor(x => x.GroupId).NotEmpty().NotNull();
        }
    }
}