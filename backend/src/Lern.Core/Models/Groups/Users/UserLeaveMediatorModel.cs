using System;
using MediatR;

namespace Lern.Core.Models.Groups.Users
{
    public class UserLeaveMediatorModel : IRequest
    {
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
    }
}