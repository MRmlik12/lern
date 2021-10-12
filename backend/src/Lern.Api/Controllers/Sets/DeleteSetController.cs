using System;
using System.Security.Claims;
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
    public class DeleteSetController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        
        public DeleteSetController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSet([FromQuery] Guid id)
        {
            await _mediator.Send(new DeleteSetMediatorModel
            {
                UserId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!),
                SetId = id
            });
            await _unitOfWork.CompleteAsync();
            
            return Ok();
        }
    }
}