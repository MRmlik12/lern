using System;
using MediatR;

namespace Lern.Core.Models.Sets
{
    public record EditSetMediatorModel : EditSetModel, IRequest
    {
        public Guid UserId { get; set; }
    }
}