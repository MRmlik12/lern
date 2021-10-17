using System;
using MediatR;

namespace Lern.Core.Models.Groups
{
    public class DeleteGroupMediatorModel : IRequest
    {
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
    }
}