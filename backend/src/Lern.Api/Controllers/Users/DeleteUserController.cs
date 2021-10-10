using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Lern.Core.Models.Users;
using Lern.Infrastructure.Database.Interfaces;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Users
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("/user/[controller]")]
    public class DeleteUserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        
        public DeleteUserController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await _mediator.Send(new DeleteUserModel
            {
                Id = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!)
            });
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}