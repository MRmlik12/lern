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
    public class GetLatestAddedSetsController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public GetLatestAddedSetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetLatestAddedSets()
        {
            var sets = await _mediator.Send(new GetLatestAddedSetsMediatorModel
            {
                Now = DateTime.Now
            });
            
            return Ok(sets);
        }
    }
}