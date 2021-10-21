namespace Lern.Infrastructure.Cloudinary.Interfaces
{
    public interface ICloudinaryClient
    {
        CloudinaryDotNet.Cloudinary Client { get; }
    }
}