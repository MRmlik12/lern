using System;
using Lern.Core.ProjectAggregate.Set.Dtos;
using MediatR;

namespace Lern.Core.Models.Sets
{
    public class GetSetMediatorModel : IRequest<SetDto>
    {
        public Guid SetId { get; set; }
    }
}