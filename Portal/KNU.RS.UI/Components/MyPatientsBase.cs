using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Services.PatientService;
using KNU.RS.UI.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class MyPatientsBase : PageBase
    {
        [Inject]
        protected IPatientService PatientService { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContextAccessor { get; set; }

        protected List<PatientInfo> PatientsList { get; set; }

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

            var patients = await PatientService.GetInfoByDoctorUserAsync(userId);
            PatientsList = patients.ToList();

            IsLoading = false;
        }
    }
}
