using Lern.Core.ProjectAggregate.User.Dtos;
using MediatR;

namespace Lern.Core.Models.Users
{
    public record RegisterUserModel : UserModel, IRequest<UserDto>
    {
        public string Username { get; set; }
    }
}