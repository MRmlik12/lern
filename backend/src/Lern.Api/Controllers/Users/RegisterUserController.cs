using System.Threading.Tasks;
using Lern.Core.Interfaces;
using Lern.Core.Models.Users;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Users
{
    [ApiController]
    [Route("/user/[controller]")]
    public class RegisterUserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        
        public RegisterUserController(IMediator mediator, IUnitOfWork unitOfWork, IJwtService jwtService)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUserModel registerUserModel)
        {
            var userDto = await _mediator.Send(registerUserModel);
            await _unitOfWork.CompleteAsync();

            
            return Ok(_jwtService.GetGeneratedJwtToken(userDto));
        }
    }
}