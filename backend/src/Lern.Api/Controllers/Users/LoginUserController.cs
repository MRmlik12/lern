using System.Threading.Tasks;
using Lern.Core.Interfaces;
using Lern.Core.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Users
{
    [ApiController]
    [Route("/user/[controller]")]
    public class LoginUserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtService _jwtService;

        public LoginUserController(IMediator mediator, IJwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserModel loginUserModel)
        {
            var userDto = await _mediator.Send(loginUserModel);

            return Ok(_jwtService.GetGeneratedJwtToken(userDto));
        }
    }
}