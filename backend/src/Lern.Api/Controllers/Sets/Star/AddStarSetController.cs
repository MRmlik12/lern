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
    public class AddStarSetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddStarSetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddStarSet([FromQuery] Guid setId)
        {
            await _mediator.Send(new AddStarMediatorModel
            {
                UserId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!),
                SetId = setId
            });

            return Ok();
        }
    }
}