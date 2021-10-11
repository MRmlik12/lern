using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Lern.Core.Models.Users.Settings;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Users.Settings
{
    [Authorize]
    [ApiController]
    [Route("user/settings/[controller]")]
    public class ChangePasswordController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        
        public ChangePasswordController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ChangePasswordModel resetPasswordModel)
        {
            var resetPasswordMediatorModel = new ChangePasswordMediatorModel
            {
                Id = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!),
                OldPassword = resetPasswordModel.OldPassword,
                NewPassword = resetPasswordModel.NewPassword
            };
            
            await _mediator.Send(resetPasswordMediatorModel);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}