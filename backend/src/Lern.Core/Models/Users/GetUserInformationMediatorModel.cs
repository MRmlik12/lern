using System;
using Lern.Core.ProjectAggregate.User.Dtos;
using MediatR;

namespace Lern.Core.Models.Users
{
    public class GetUserInformationMediatorModel : IRequest<UserInfoDto>
    {
        public Guid UserId { get; set; }
    }
}