using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Lern.Core.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Users
{
    [Authorize]
    [ApiController]
    [Route("user/[controller]")]
    public class GetUserInformationController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public GetUserInformationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUserInformation([FromQuery] Guid? userId)
        {
            var user = await _mediator.Send(new GetUserInformationMediatorModel
            {
                UserId = userId ?? Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!)
            });
            
            return Ok(user);
        }
    }
}