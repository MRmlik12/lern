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
    public class UserLeaveController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public UserLeaveController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public async Task<IActionResult> UserLeave([FromBody] UserLeaveModel userLeaveModel)
        {
            await _mediator.Send(new UserLeaveMediatorModel
            {
                UserId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!),
                GroupId = userLeaveModel.GroupId
            });
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}