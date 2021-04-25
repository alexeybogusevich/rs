using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.Doctor;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace KNU.RS.UI.Components
{
    public class DoctorProfileBase : ComponentBase
    {
        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }

        [Parameter]
        public DoctorInfo Doctor { get; set; }

        protected string GetPhotoURI()
        {
            if (Doctor.HasPhoto)
            {
                return $"{StaticFileConstants.PhotosRequestPath}/{Doctor.UserId}.{Options.Value.Extension}";
            }

            return "img/user.jpg";
        }
    }
}
