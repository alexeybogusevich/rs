using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.AccountService;
using KNU.RS.Logic.Services.ClinicService;
using KNU.RS.Logic.Services.QualificationService;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class NewDoctorBase : ComponentBase
    {
        [Inject]
        protected IAccountService AccountService { get; set; }

        [Inject]
        protected IClinicService ClinicService { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected IQualificationService QualificationService { get; set; }


        protected bool IsLoading { get; set; } = true;


        protected IEnumerable<Clinic> Clinics { get; set; }

        protected IEnumerable<Qualification> Qualifications { get; set; }


        protected DoctorRegistrationModel RegistrationModel { get; set; } = new DoctorRegistrationModel();


        protected void AssignPhoto(InputFileChangeEventArgs e)
        {
            RegistrationModel.Photo = e.File;
        }

        protected void AssignQualification(ChangeEventArgs e)
        {
            RegistrationModel.QualificationId = (Guid) e.Value;
        }

        protected async Task SaveDoctorAsync()
        {
            IsLoading = true;
            await AccountService.RegisterAsync(RegistrationModel);
            IsLoading = false;

            NavigationManager.NavigateTo("/doctors");
        }

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            Qualifications = await QualificationService.GetAsync();
            Clinics = await ClinicService.GetAsync();
            IsLoading = false;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.SetSelect2);
        }
    }
}
