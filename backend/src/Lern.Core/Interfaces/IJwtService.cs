using Lern.Core.ProjectAggregate.User.Dtos;

namespace Lern.Core.Interfaces
{
    public interface IJwtService
    {
        string GetGeneratedJwtToken(UserDto userDto);
    }
}