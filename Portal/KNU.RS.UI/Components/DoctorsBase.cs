using KNU.RS.Logic.Models.Doctor;
using KNU.RS.Logic.Services.DoctorService;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class DoctorsBase : ComponentBase
    {
        [Inject]
        protected IDoctorService DoctorService { get; set; }


        protected bool IsLoading { get; set; } = true;

        public List<DoctorInfo> DoctorsList { get; set; }


        protected override async Task OnInitializedAsync()
        {
            var doctors = await DoctorService.GetInfoAsync();
            DoctorsList = doctors.ToList();
            IsLoading = false;
        }
    }
}
