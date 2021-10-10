using System;
using MediatR;

namespace Lern.Core.Models.Users
{
    public class DeleteUserModel : IRequest
    {
        public Guid Id { get; set; }
    }
}