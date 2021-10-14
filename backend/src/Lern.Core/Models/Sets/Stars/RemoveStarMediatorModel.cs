using System;
using MediatR;

namespace Lern.Core.Models.Sets.Stars
{
    public class RemoveStarMediatorModel : IRequest
    {
        public Guid UserId { get; set; }
        public Guid SetId { get; set; }
    }
}