using FluentValidation;
using Lern.Core.Models.Sets;

namespace Lern.Core.Validators.Sets
{
    public class EditSetModelValidator : AbstractValidator<EditSetModel>
    {
        public EditSetModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Title).MinimumLength(4).NotEmpty();
            RuleFor(x => x.Language).NotEmpty();
            RuleForEach(x => x.Tags).MinimumLength(1).NotEmpty();
            RuleForEach(x => x.Items).SetValidator(new SetItemValidator()).NotEmpty();
        }
    }
}