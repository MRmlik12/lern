using System.Threading.Tasks;
using Lern.Core.Models.Sets;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Sets
{
    [ApiController]
    [Route("set/[controller]")]
    public class CreateSetController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        
        public CreateSetController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSet([FromBody] CreateSetModel createSetModel)
        {
            await _mediator.Send(createSetModel);
            await _unitOfWork.CompleteAsync();
            
            return Ok();
        }
    }
}