using KNU.RS.Logic.Models.Doctor;
using KNU.RS.Logic.Services.DoctorService;
using KNU.RS.UI.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class MyDoctorProfileBase : PageBase
    {
        [Inject]
        protected IDoctorService DoctorService { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContextAccessor { get; set; }


        protected DoctorInfo Doctor { get; set; }

        protected bool IsLoading { get; set; } = true;


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            if (!Guid.TryParse(
                HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                out var userId))
            {
                NavigationManager.NavigateUnauthorized();
            }

            Doctor = await DoctorService.GetInfoAsync(userId, cancellationTokenSource.Token);

            IsLoading = false;
        }
    }
}
