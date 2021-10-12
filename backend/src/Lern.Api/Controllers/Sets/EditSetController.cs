using System.Threading.Tasks;
using Lern.Core.Models.Sets;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Sets
{
    [Authorize]
    [ApiController]
    [Route("set/[controller]")]
    public class EditSetController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        
        public EditSetController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpPut]
        public async Task<IActionResult> EditSet([FromBody] EditSetModel editSetModel)
        {
            await _mediator.Send((EditSetMediatorModel) editSetModel);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}