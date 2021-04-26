using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace KNU.RS.UI.Components
{
    public class PanelBase : ComponentBase
    {
        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }

        protected string GetPhotoURI(PatientInfo patient)
        {
            if (patient.HasPhoto)
            {
                return $"{StaticFileConstants.PhotosRequestPath}/{patient.UserId}.{Options.Value.Extension}";
            }

            return "img/user.jpg";
        }
    }
}
