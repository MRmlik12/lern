using System;
using MediatR;

namespace Lern.Core.Models.Groups
{
    public class CreateGroupModel : IRequest
    {
        public string Name { get; set; }
    }
}