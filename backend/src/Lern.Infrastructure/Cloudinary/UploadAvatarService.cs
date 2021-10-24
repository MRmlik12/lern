using System;
using System.IO;
using System.Text;
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

        public async Task<string> UploadAvatar(string avatar, Guid id)
        {
            await using var memStream = new MemoryStream();
            await memStream.WriteAsync(Encoding.UTF8.GetBytes(avatar));
            
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(id.ToString(), avatar)
            };
            var uploadResult = await Client.UploadAsync(uploadParams);

            return uploadResult.Url.ToString();
        }
    }
}