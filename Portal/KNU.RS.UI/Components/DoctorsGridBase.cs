using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.Doctor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace KNU.RS.UI.Components
{
    public class DoctorsGridBase : ComponentBase
    {
        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }


        [Parameter]
        public List<DoctorInfo> Doctors { get; set; } = new List<DoctorInfo>();


        //protected string GetPhotoURI(DoctorInfo doctor)
        //{
        //    if (doctor.HasPhoto)
        //    {
        //        return $"{Options.Value.BasePath}{doctor.Id}.{Options.Value.Extension}";
        //    }

        //    return "img/user.jpg";
        //}
    }
}
