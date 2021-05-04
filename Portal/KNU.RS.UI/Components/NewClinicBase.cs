using KNU.RS.Logic.Models.Clinic;
using KNU.RS.Logic.Services.ClinicService;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class NewClinicBase : PageBase
    {
        [Inject]
        protected IClinicService ClinicService { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        protected ClinicModel CreateModel { get; set; } = new ClinicModel();

        protected bool IsLoading { get; set; }

        protected async Task SaveAsync()
        {
            IsLoading = true;
            await ClinicService.CreateAsync(CreateModel);
            IsLoading = false;

            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.BackToPreviousPage);
        }
    }
}
