using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Sets;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Sets
{
    public class DeleteSetRequestHandler : IRequestHandler<DeleteSetMediatorModel, Unit>
    {
        private readonly ISetRepository _setRepository;
        
        public DeleteSetRequestHandler(ISetRepository setRepository)
        {
            _setRepository = setRepository;
        }
        
        public async Task<Unit> Handle(DeleteSetMediatorModel request, CancellationToken cancellationToken)
        {
            var set = await _setRepository.GetSetById(request.SetId, request.UserId);
            await _setRepository.Delete(set);
            
            return Unit.Value;
        }
    }
}