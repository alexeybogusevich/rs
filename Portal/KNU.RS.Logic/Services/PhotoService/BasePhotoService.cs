using KNU.RS.Logic.Configuration;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.PhotoService
{
    public class BasePhotoService : IPhotoService
    {
        private readonly PhotoConfiguration configuration;

        public BasePhotoService(IOptions<PhotoConfiguration> options)
        {
            this.configuration = options.Value;
        }

        public async Task<byte[]> ValidateAndGetBytesAsync(IBrowserFile file)
        {
            var croppedImage = await file.RequestImageFileAsync(
                configuration.Format, configuration.MaxHeight, configuration.MaxWidth);

            using var reader = croppedImage.OpenReadStream();
            using var ms = new MemoryStream();

            await reader.CopyToAsync(ms);
            return ms.ToArray();
        }

        public async Task UploadAsync(Guid id, byte[] bytes)
        {
            var imageExtension = configuration.Format.Split('/').Last();
            using var fileStream = File.Create($"{configuration.BasePath}{id}.{imageExtension}");
            await fileStream.WriteAsync(bytes);
        }
    }
}
