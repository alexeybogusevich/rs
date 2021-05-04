using KNU.RS.Logic.Models.Doctor;
using KNU.RS.Logic.Services.DoctorService;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class ViewDoctorBase : PageBase
    {
        [Inject]
        protected IDoctorService DoctorService { get; set; }


        [Parameter]
        public Guid Id { get; set; }


        protected DoctorInfo Doctor { get; set; }

        protected bool IsLoading { get; set; } = true;


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            Doctor = await DoctorService.GetInfoAsync(Id, cancellationTokenSource.Token);
            IsLoading = false;
        }
    }
}
