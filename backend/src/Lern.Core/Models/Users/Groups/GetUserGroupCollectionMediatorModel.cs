using System;
using System.Collections.Generic;
using Lern.Core.ProjectAggregate.User.Dtos;
using MediatR;

namespace Lern.Core.Models.Users.Groups
{
    public class GetUserGroupCollectionMediatorModel : IRequest<List<UserGroupDto>>
    {
        public Guid UserId { get; set; }
    }
}