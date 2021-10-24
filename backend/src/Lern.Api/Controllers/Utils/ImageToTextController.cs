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
        
        [HttpPost]
        [RequestSizeLimit(100_100_100_100)]
        public async Task<IActionResult> ImageToText([FromBody] ImageToTextModel imageToTextModel)
        {
            var result = await _mediator.Send(new ImageToTextMediatorModel
            {
                ImageData = $"data:image/png;base64,{imageToTextModel.ImageData}"
            });

            return Ok(result);
        }
    }
}