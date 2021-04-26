using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.Doctor;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Services.PatientService;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class DoctorProfileBase : ComponentBase
    {
        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }

        [Inject]
        protected IPatientService PatientService { get; set; }

        [Parameter]
        public DoctorInfo Doctor { get; set; }

        protected List<PatientInfo> DoctorPatients { get; set; } = new List<PatientInfo>();

        protected override async Task OnParametersSetAsync()
        {
            var patients = await PatientService.GetInfoAsync(); // make by doctor
            DoctorPatients = patients?.ToList();
        }

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
