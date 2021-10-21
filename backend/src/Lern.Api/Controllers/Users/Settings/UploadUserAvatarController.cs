using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Lern.Core.Models.Users.Settings;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Users.Settings
{
    [Authorize]
    [ApiController]
    [Route("user/settings/[controller]")]
    public class UploadUserAvatarController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        
        public UploadUserAvatarController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> UploadUserAvatar(IFormFile file)
        {
            await _mediator.Send(new UploadUserAvatarMediatorModel
            {
                UserId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!),
                Avatar = file
            });
            await _unitOfWork.CompleteAsync();
            
            return Ok();
        }
    }
}