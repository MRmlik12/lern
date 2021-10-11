using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Lern.Core.Models.Users.Settings;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Users.Settings
{
    [ApiController]
    [Route("user/options/[controller]")]
    public class ChangeUsernameController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        
        public ChangeUsernameController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpPut]
        public async Task<IActionResult> ChangeUsername([FromBody] ChangeUsernameModel changeUsernameModel)
        {
            await _mediator.Send(new ChangeUsernameMediatorModel
            {
                Id = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!),
                NewUsername = changeUsernameModel.NewUsername
            });
            
            await _unitOfWork.CompleteAsync();
            
            return Ok();
        }
    }
}