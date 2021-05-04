using KNU.RS.Logic.Models.Doctor;
using KNU.RS.Logic.Services.DoctorService;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class DoctorsBase : PageBase
    {
        [Inject]
        protected IDoctorService DoctorService { get; set; }

        protected bool IsLoading { get; set; }

        public List<DoctorInfo> DoctorsList { get; set; }


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            var doctors = await DoctorService.GetInfoAsync(cancellationTokenSource.Token);
            DoctorsList = doctors.ToList();

            IsLoading = false;
        }
    }
}
