using Lern.Core.ProjectAggregate.User.Dtos;
using MediatR;

namespace Lern.Core.Models.Users
{
    public record RegisterUserModel : IRequest<UserDto>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}