using System;
using MediatR;

namespace Lern.Core.Models.Users.Settings
{
    public record ChangeUsernameMediatorModel : IRequest
    {
        public Guid Id { get; set; }
        public string NewUsername { get; set; }
    }
}