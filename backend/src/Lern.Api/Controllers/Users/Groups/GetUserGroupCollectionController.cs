using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Lern.Core.Models.Users.Groups;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Users.Groups
{
    [Authorize]
    [ApiController]
    [Route("user/group/[controller]")]
    public class GetUserGroupCollectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetUserGroupCollectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserGroupCollection()
        {
            var groupCollection = await _mediator.Send(new GetUserGroupCollectionMediatorModel
            {
                UserId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!)
            });

            return Ok(groupCollection);
        }
    }
}