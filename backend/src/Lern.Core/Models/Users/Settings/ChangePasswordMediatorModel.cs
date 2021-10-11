using System;
using MediatR;

namespace Lern.Core.Models.Users.Settings
{
    public record ChangePasswordMediatorModel : IRequest
    {
        public Guid Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}