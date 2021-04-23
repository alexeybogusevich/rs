using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.PhotoService
{
    public interface IPhotoService
    {
        Task UploadAsync(Guid id, IBrowserFile image);
    }
}