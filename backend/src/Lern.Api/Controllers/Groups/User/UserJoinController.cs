using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Lern.Core.Models.Groups.Users;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Groups.User
{
    [Authorize]
    [ApiController]
    [Route("group/user/[controller]")]
    public class UserJoinController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        
        public UserJoinController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> UserJoin([FromBody] UserJoinModel userJoinModel)
        {
            await _mediator.Send(new UserJoinMediatorModel
            {
                UserId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!),
                Code = userJoinModel.Code
            });
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}