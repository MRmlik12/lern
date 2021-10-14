using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Lern.Core.Models.Sets.Stars;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Sets.Star
{
    [Authorize]
    [ApiController]
    [Route("set/star/[controller]")]
    public class RemoveStarController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public RemoveStarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveStar([FromQuery] Guid setId)
        {
            await _mediator.Send(new RemoveStarMediatorModel
            {
                UserId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!),
                SetId = setId
            });
            
            return Ok();
        }
    }
}