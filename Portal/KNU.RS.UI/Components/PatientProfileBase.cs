using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Services.PatientService;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace KNU.RS.UI.Components
{
    public class PatientProfileBase : ComponentBase
    {
        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }

        [Inject]
        protected IPatientService PatientService { get; set; }


        [Parameter]
        public PatientInfo Patient { get; set; }

        protected string GetPhotoURI()
        {
            if (Patient.HasPhoto)
            {
                return $"{StaticFileConstants.PhotosRequestPath}/{Patient.UserId}.{Options.Value.Extension}";
            }

            return "img/user.jpg";
        }
    }
}
