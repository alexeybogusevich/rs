using KNU.RS.Logic.Models.Doctor;
using KNU.RS.Logic.Services.DoctorService;
using KNU.RS.UI.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class MyDoctorProfileBase : PageBase
    {
        [Inject]
        protected IDoctorService DoctorService { get; set; }


        protected DoctorInfo Doctor { get; set; }


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            var authenticationState = await AuthenticationStateTask!;

            if (!Guid.TryParse(
                authenticationState?.User?.FindFirstValue(ClaimTypes.NameIdentifier),
                out var userId))
            {
                NavigationManager.NavigateUnauthorized();
            }

            Doctor = await DoctorService.GetInfoAsync(userId, cancellationTokenSource.Token);

            IsLoading = false;
        }
    }
}
