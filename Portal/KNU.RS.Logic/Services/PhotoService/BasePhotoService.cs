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

        public async Task UploadAsync(Guid id, IBrowserFile image)
        {
            var croppedImage = await image.RequestImageFileAsync(
                configuration.Format, configuration.MaxHeight, configuration.MaxWidth);

            using var reader = croppedImage.OpenReadStream();

            var imageExtension = configuration.Format.Split('/').Last();
            using var fileStream = File.Create($"{configuration.BasePath}{id}.{imageExtension}");

            reader.CopyTo(fileStream);
        }
    }
}
