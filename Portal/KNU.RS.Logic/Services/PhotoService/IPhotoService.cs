using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.PhotoService
{
    public interface IPhotoService
    {
        Task<byte[]> ValidateAndGetBytesAsync(IBrowserFile file);
        Task UploadAsync(Guid id, byte[] bytes);
        void DeleteAsync(Guid id);
    }
}