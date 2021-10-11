using FluentValidation;
using Lern.Core.ProjectAggregate.Set;

namespace Lern.Core.Validators.Sets
{
    public class SetItemValidator : AbstractValidator<SetItem>
    {
        public SetItemValidator()
        {
            RuleFor(x => x.PrimaryWord).NotEmpty();
            RuleFor(x => x.TranslatedWord).NotEmpty();
        }
    }
}