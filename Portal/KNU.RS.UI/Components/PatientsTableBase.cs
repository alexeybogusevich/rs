using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace KNU.RS.UI.Components
{
    public class PatientsTableBase : ComponentBase
    {
        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }


        [Parameter]
        public List<PatientInfo> Patients { get; set; }

        protected int Counter = 1;


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
