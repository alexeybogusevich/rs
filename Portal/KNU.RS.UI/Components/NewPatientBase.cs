using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.AccountService;
using KNU.RS.Logic.Services.PhotoService;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class NewPatientBase : PageBase
    {
        [Inject]
        protected IAccountService AccountService { get; set; }

        [Inject]
        protected IPhotoService PhotoService { get; set; }


        protected PatientRegistrationModel RegistrationModel { get; set; } = new PatientRegistrationModel();


        protected override void OnInitialized()
        {
            IsLoading = false;
        }

        protected async Task AssignPhotoAsync(InputFileChangeEventArgs e)
        {
            RegistrationModel.Photo = await PhotoService.ValidateAndGetBytesAsync(e.File, cancellationTokenSource.Token);
        }

        protected async Task SavePatientAsync()
        {
            IsLoading = true;
            await AccountService.RegisterAsync(RegistrationModel);
            IsLoading = false;

            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.BackToPreviousPage);
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
