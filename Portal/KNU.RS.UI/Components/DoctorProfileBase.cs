using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.Doctor;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Services.AccountService;
using KNU.RS.Logic.Services.PatientService;
using KNU.RS.UI.Constants;
using KNU.RS.UI.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class DoctorProfileBase : PageBase
    {
        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }

        [Inject]
        protected IPatientService PatientService { get; set; }

        [Inject]
        protected IAccountService AccountService { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContextAccessor { get; set; }


        [Parameter]
        public DoctorInfo Doctor { get; set; }

        protected List<PatientInfo> DoctorPatients { get; set; } = new List<PatientInfo>();

        protected bool IsLoading { get; set; }

        protected Guid CurrentUserId { get; set; }


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            if (!Guid.TryParse(
                HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                out var userId))
            {
                NavigationManager.NavigateUnauthorized();
            }

            var patients = await PatientService.GetInfoByDoctorAsync(Doctor.Id);
            DoctorPatients = patients?.ToList();
            CurrentUserId = userId;

            IsLoading = false;
        }

        protected async Task SetPromoteToAdminAsync()
        {
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ToggleModal, "promote-doctor");
        }

        protected async Task PromoteToAdminAsync()
        {
            IsLoading = true;

            await AccountService.PromoteToAdminAsync(Doctor.UserId);
            Doctor.PromotedToAdmin = true;

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
