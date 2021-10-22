using CloudinaryDotNet;
using Lern.Infrastructure.Cloudinary.Interfaces;
using CloudinaryConfiguration = Lern.Core.Configuration.CloudinaryConfiguration;

namespace Lern.Infrastructure.Cloudinary
{
    public class CloudinaryClient : ICloudinaryClient
    {
        public CloudinaryDotNet.Cloudinary Client { get; }

        public CloudinaryClient(CloudinaryConfiguration configuration)
        {
            var account = new Account(
                configuration.Cloud,
                configuration.ApiKey,
                configuration.ApiSecret
            );
            Client = new CloudinaryDotNet.Cloudinary(account)
            {
                Api =
                {
                    Secure = true
                }
            };
        }
    }
}