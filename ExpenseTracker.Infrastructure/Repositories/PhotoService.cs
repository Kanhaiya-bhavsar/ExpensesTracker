using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ExpenseTracker.Domain.Repositories;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
       

        public PhotoService(IOptions<CloudinarySettings> config)
        {
           

            var settings = config.Value;

           

            var account = new CloudinaryDotNet.Account(settings.CloudName, settings.ApiKey, settings.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
               
                return null;
            }

         
            await using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Width(600).Height(600).Crop("limit")
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                 return null;
            }

           
            return uploadResult.SecureUrl?.ToString();
        }
    }
}
