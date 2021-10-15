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
    [Route("groups/[controller]")]
    public class CreateGroupController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public CreateGroupController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupModel createGroupModel)
        {
            var shareCode = await _mediator.Send(new CreateGroupMediatorModel
            {
                UserId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!),
                Name = createGroupModel.Name
            });

            await _unitOfWork.CompleteAsync();
            
            return Ok(shareCode);
        }
    }
}