using System;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Lern.Infrastructure.Cloudinary.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Lern.Infrastructure.Cloudinary
{
    public class UploadAvatarService : IUploadAvatarService
    {
        private CloudinaryDotNet.Cloudinary Client { get; }
        
        public UploadAvatarService(ICloudinaryClient cloudinary)
        {
            Client = cloudinary.Client;
        }

        public async Task<string> UploadAvatar(IFormFile avatar, Guid userId)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(userId.ToString(), avatar.OpenReadStream())
            };
            var uploadResult = await Client.UploadAsync(uploadParams);
            
            return uploadResult.Url.ToString();
        }
    }
}