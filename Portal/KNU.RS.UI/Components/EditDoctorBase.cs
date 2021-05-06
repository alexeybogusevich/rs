using KNU.RS.Data.Enums;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Converters;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.AccountService;
using KNU.RS.Logic.Services.ClinicService;
using KNU.RS.Logic.Services.DoctorService;
using KNU.RS.Logic.Services.PhotoService;
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
    public class EditDoctorBase : PageBase
    {
        [Inject]
        protected IAccountService AccountService { get; set; }

        [Inject]
        protected IClinicService ClinicService { get; set; }

        [Inject]
        protected IDoctorService DoctorService { get; set; }

        [Inject]
        protected IPhotoService PhotoService { get; set; }

        [Inject]
        protected IQualificationService QualificationService { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        protected IEnumerable<Clinic> Clinics { get; set; }

        protected IEnumerable<Qualification> Qualifications { get; set; }

        protected DoctorRegistrationModel EditModel { get; set; } = new DoctorRegistrationModel();

        protected bool IsMaleGender { get; set; } = true;


        protected async Task AssignPhotoAsync(InputFileChangeEventArgs e)
        {
            EditModel.Photo = await PhotoService.ValidateAndGetBytesAsync(e.File, cancellationTokenSource.Token);
        }

        protected async Task SaveDoctorAsync()
        {
            IsLoading = true;

            await AccountService.EditAsync(EditModel);

            IsLoading = false;

            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.BackToPreviousPage);
        }

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            Qualifications = await QualificationService.GetAsync(cancellationTokenSource.Token);
            Clinics = await ClinicService.GetAsync(cancellationTokenSource.Token);

            var doctor = await DoctorService.GetAsync(Id, cancellationTokenSource.Token);
            EditModel = DoctorConverter.ConvertProfile(doctor);
            IsMaleGender = EditModel.Gender.Equals(Gender.Male);

            IsLoading = false;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.SetSelect2);

            var dotNetReference = DotNetObjectReference.Create(this);
            await JsRuntime.InvokeVoidAsync(
                JSExtensionMethods.SetOnChangeSelect2, "select-clinic", dotNetReference, JSInvokableMethods.ChangeClinic);

            await JsRuntime.InvokeVoidAsync(
                JSExtensionMethods.SetOnChangeSelect2, "select-qualification", dotNetReference, JSInvokableMethods.ChangeQualification);
        }
    }
}
