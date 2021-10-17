using System;
using MediatR;

namespace Lern.Core.Models.Groups.Users
{
    public class UserJoinMediatorModel : IRequest
    {
        public Guid UserId { get; set; }
        public string Code { get; set; }
    }
}