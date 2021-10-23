using System.Threading.Tasks;
using Lern.Core.Models.Utils;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Utils
{
    [Authorize]
    [ApiController]
    [Route("utils/[controller]")]
    public class ImageToTextController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ImageToTextController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> ImageToText([FromQuery] string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
                return BadRequest();

            var result = await _mediator.Send(new ImageToTextMediatorModel()
            {
                ImageUrl = imageUrl
            });

            return Ok(result);
        }
    }
}