using System;
using MediatR;

namespace Lern.Core.Models.Groups
{
    public class CreateGroupMediatorModel : IRequest<string>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}