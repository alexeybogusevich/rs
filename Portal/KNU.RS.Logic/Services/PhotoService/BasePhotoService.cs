using KNU.RS.Logic.Configuration;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading;
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

        public async Task<byte[]> ValidateAndGetBytesAsync(IBrowserFile file, CancellationToken cancellationToken = default)
        {
            var croppedImage = await file.RequestImageFileAsync(
                configuration.Format, configuration.MaxHeight, configuration.MaxWidth);

            using var reader = croppedImage.OpenReadStream();
            using var ms = new MemoryStream();

            await reader.CopyToAsync(ms, cancellationToken);
            return ms.ToArray();
        }

        public async Task UploadAsync(Guid id, byte[] bytes)
        {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), configuration.UploadPath);
            using var fileStream = File.Create($"{uploadPath}{id}.{configuration.Extension}");
            await fileStream.WriteAsync(bytes);
        }

        public void DeleteAsync(Guid id)
        {
            var deletePath = Path.Combine(Directory.GetCurrentDirectory(), configuration.UploadPath);
            var path = $"{deletePath}{id}.{configuration.Extension}";
            using (new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 1, FileOptions.DeleteOnClose | FileOptions.Asynchronous)) { }
        }
    }
}
