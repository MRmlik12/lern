using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Lern.Core.Models.Sets;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers.Sets
{
    [Authorize]
    [ApiController]
    [Route("set/[controller]")]
    public class CreateSetController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        
        public CreateSetController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSet([FromBody] CreateSetModel createSetModel)
        {
            await _mediator.Send(new CreateSetMediatorModel
            {
                Id = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!),
                Title = createSetModel.Title,
                Language = createSetModel.Language,
                Tags = createSetModel.Tags,
                Items = createSetModel.Items
            });
            await _unitOfWork.CompleteAsync();
            
            return Ok();
        }
    }
}