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

        protected bool IsLoading { get; set; }


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            var patients = await PatientService.GetInfoByDoctorAsync(Doctor.Id);
            DoctorPatients = patients?.ToList();

            IsLoading = false;
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
