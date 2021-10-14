using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Sets.Stars;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Sets.Star
{
    public class RemoveStarRequestHandler : IRequestHandler<RemoveStarMediatorModel, Unit>
    {
        private readonly ISetRepository _setRepository;
        
        public RemoveStarRequestHandler(ISetRepository setRepository)
        {
            _setRepository = setRepository;
        }
        
        public async Task<Unit> Handle(RemoveStarMediatorModel request, CancellationToken cancellationToken)
        {
            var set = await _setRepository.GetSetById(request.SetId);

            var userInStars = set.Stars.Find(x => x.Id == request.UserId);
            set.Stars.Remove(userInStars);
            
            await _setRepository.Update(set);

            return Unit.Value;
        }
    }
}