using System;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Lern.Core.Models.Users.Settings
{
    public class UploadUserAvatarMediatorModel : IRequest
    {
        public Guid UserId { get; set; }
        public string Avatar { get; set; }
    }
}