using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Lern.Infrastructure.Cloudinary.Interfaces
{
    public interface IUploadAvatarService
    {
        Task<string> UploadAvatar(IFormFile avatar, Guid userId);
    }
}