using Lern.Core.ProjectAggregate.User.Dtos;
using MediatR;

namespace Lern.Core.Models.Users
{
    public record LoginUserModel : UserModel, IRequest<UserDto>
    {
    }
}