using System;
using System.Threading.Tasks;
using Lern.Core.Models.Sets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Sets
{
    [Authorize]   
    [ApiController]
    [Route("set/[controller]")]
    public class GetSetController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public GetSetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSet([FromQuery] Guid setId)
        {
            var setDto = await _mediator.Send(new GetSetMediatorModel
            {
                SetId = setId
            });

            return Ok(setDto);
        }
    }
}