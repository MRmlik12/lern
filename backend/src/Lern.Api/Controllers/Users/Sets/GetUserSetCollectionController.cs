using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Lern.Core.Models.Users.Sets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Users.Sets
{
    [Authorize]
    [ApiController]
    [Route("user/set/[controller]")]
    public class GetUserSetCollectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetUserSetCollectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserSetCollection([FromQuery] Guid? userId, int page = 1)
        {
            var sets = await _mediator.Send(new UserSetCollectionMediatorModel
            {
                UserId = userId ?? Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!),
                Page = page
            });
            
            return Ok(sets);
        }
    }
}