using KNU.RS.Logic.Models.Clinic;
using KNU.RS.Logic.Services.ClinicService;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class EditClinicBase : PageBase
    {
        [Inject]
        protected IClinicService ClinicService { get; set; }


        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        protected ClinicModel EditModel { get; set; } = new ClinicModel();

        protected bool IsLoading { get; set; }

        [Parameter]
        public Guid Id { get; set; }


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            EditModel = await ClinicService.GetModelAsync(Id, cancellationTokenSource.Token);
            IsLoading = false;
        }

        protected async Task UpdateAsync()
        {
            IsLoading = true;
            await ClinicService.UpdateAsync(EditModel);
            IsLoading = false;

            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.BackToPreviousPage);
        }
    }
}
