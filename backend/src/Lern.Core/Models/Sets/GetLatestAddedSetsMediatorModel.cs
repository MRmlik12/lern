using System;
using System.Collections.Generic;
using Lern.Core.ProjectAggregate.Set.Dtos;
using MediatR;

namespace Lern.Core.Models.Sets
{
    public class GetLatestAddedSetsMediatorModel : IRequest<List<SetCardItemsDto>>
    {
        public DateTime Now { get; set; }
    }
}