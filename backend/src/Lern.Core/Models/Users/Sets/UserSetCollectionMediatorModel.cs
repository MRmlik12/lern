using System;
using System.Collections.Generic;
using Lern.Core.ProjectAggregate.Set.Dtos;
using Lern.Core.ProjectAggregate.User.Dtos;
using MediatR;

namespace Lern.Core.Models.Users.Sets
{
    public class UserSetCollectionMediatorModel : IRequest<List<SetCardItemsDto>>
    {
        public Guid UserId { get; set; }
        public int Page { get; set; }
    }
}