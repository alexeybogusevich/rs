using KNU.RS.Logic.Configuration;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using System;
using System.IO;
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
            using var fileStream = File.Create($"{configuration.BasePath}{id}.{configuration.Extension}");
            await fileStream.WriteAsync(bytes);
        }

        public void DeleteAsync(Guid id)
        {
            var path = $"{configuration.BasePath}{id}.{configuration.Extension}";
            using (new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 1, FileOptions.DeleteOnClose | FileOptions.Asynchronous)) { }
        }
    }
}
