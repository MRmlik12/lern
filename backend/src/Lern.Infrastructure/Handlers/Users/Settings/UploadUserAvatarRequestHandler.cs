using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Users.Settings;
using Lern.Infrastructure.Cloudinary.Interfaces;
using Lern.Infrastructure.Database.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Users.Settings
{
    public class UploadUserAvatarRequestHandler : IRequestHandler<UploadUserAvatarMediatorModel, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUploadAvatarService _uploadAvatarService;

        public UploadUserAvatarRequestHandler(IUserRepository userRepository, IUploadAvatarService uploadAvatarService)
        {
            _userRepository = userRepository;
            _uploadAvatarService = uploadAvatarService;
        }

        public async Task<Unit> Handle(UploadUserAvatarMediatorModel request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.UserId);
            var avatarUrl = await _uploadAvatarService.UploadAvatar(request.Avatar, request.UserId);
            user.AvatarUrl = avatarUrl;
            await _userRepository.Update(user);

            return Unit.Value;
        }
    }
}