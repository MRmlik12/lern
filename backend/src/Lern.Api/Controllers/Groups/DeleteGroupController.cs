using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Lern.Core.Models.Groups;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Groups
{
    [Authorize]
    [ApiController]
    [Route("group/[controller]")]
    public class DeleteGroupController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGroupController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGroup([FromBody] DeleteGroupModel deleteGroupModel)
        {
            await _mediator.Send(new DeleteGroupMediatorModel
            {
                UserId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!),
                GroupId = deleteGroupModel.GroupId
            });

            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}