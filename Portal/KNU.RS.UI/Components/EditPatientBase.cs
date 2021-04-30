﻿using KNU.RS.Data.Enums;
using KNU.RS.Logic.Converters;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.AccountService;
using KNU.RS.Logic.Services.PatientService;
using KNU.RS.Logic.Services.PhotoService;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class EditPatientBase : ComponentBase
    {
        [Inject]
        protected IAccountService AccountService { get; set; }

        [Inject]
        protected IPatientService PatientService { get; set; }

        [Inject]
        protected IPhotoService PhotoService { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected bool IsLoading { get; set; } = true;


        protected PatientRegistrationModel EditModel { get; set; } = new PatientRegistrationModel();

        [Parameter]
        public Guid Id { get; set; }

        protected bool IsMaleGender { get; set; } = true;

        protected async Task AssignPhotoAsync(InputFileChangeEventArgs e)
        {
            EditModel.Photo = await PhotoService.ValidateAndGetBytesAsync(e.File);
        }

        protected async Task SavePatientAsync()
        {
            IsLoading = true;
            await AccountService.EditAsync(EditModel);
            IsLoading = false;

            NavigationManager.NavigateTo("/patients");
        }

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            var patient = await PatientService.GetAsync(Id);
            EditModel = PatientConverter.ConvertProfile(patient);
            IsMaleGender = EditModel.Gender.Equals(Gender.Male);

            IsLoading = false;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.SetSelect2);

            var dotNetReference = DotNetObjectReference.Create(this);
            await JsRuntime.InvokeVoidAsync(
                JSExtensionMethods.SetOnChangeSelect2, "select-marital", dotNetReference, JSInvokableMethods.ChangeMaritalStatus);

            await JsRuntime.InvokeVoidAsync(
                JSExtensionMethods.SetOnChangeSelect2, "select-education", dotNetReference, JSInvokableMethods.ChangeEducationStatus);

            await JsRuntime.InvokeVoidAsync(
                JSExtensionMethods.SetOnChangeSelect2, "select-occupation", dotNetReference, JSInvokableMethods.ChangeOccupation);
        }
    }
}
