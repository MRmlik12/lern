using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Lern.Infrastructure.Cloudinary.Interfaces
{
    public interface IUploadImageService
    {
        Task<string> UploadImage(string avatar, Guid id);
    }
}