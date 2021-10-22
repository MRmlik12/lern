using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Users;
using Lern.Core.ProjectAggregate.User.Dtos;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Users
{
    public class GetUserRequestHandler : IRequestHandler<GetUserInformationMediatorModel, UserInfoDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISetRepository _setRepository;
        private readonly IGroupRepository _groupRepository;
        
        
        public GetUserRequestHandler(
            IUserRepository userRepository,
            ISetRepository setRepository,
            IGroupRepository groupRepository)
        {
            _userRepository = userRepository;
            _setRepository = setRepository;
            _groupRepository = groupRepository;
        }
        
        public async Task<UserInfoDto> Handle(GetUserInformationMediatorModel request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.UserId);
            var setCount = await _setRepository.GetUserSetCount(request.UserId);
            var groupsCount = await _groupRepository.GetUserSetCount(request.UserId);

            return new UserInfoDto
            {
                Id = user.Id,
                Name = user.Username,
                AvatarUrl = user.AvatarUrl,
                CreatedAt = user.CreatedAt,
                SetCount = setCount,
                GroupsCount = groupsCount,
            };
        }
    }
}