using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Sets;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Sets
{
    public class EditSetRequestHandler : IRequestHandler<EditSetMediatorModel, Unit>
    {
        private readonly ISetRepository _setRepository;

        public EditSetRequestHandler(ISetRepository setRepository)
        {
            _setRepository = setRepository;
        }

        public async Task<Unit> Handle(EditSetMediatorModel request, CancellationToken cancellationToken)
        {
            var set = await _setRepository.GetSetByIdAndUserId(request.Id, request.UserId);

            set.Title = request.Title;
            set.Language = request.Language;
            set.Tags = request.Tags;
            set.Items = request.Items;

            await _setRepository.Update(set.UpdateTimestamp());

            return Unit.Value;
        }
    }
}