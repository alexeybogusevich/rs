using KNU.RS.Logic.Models.Clinic;
using KNU.RS.Logic.Services.ClinicService;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class ClinicsTableBase : PageBase
    {
        [Inject]
        protected IClinicService ClinicService { get; set; }


        [Parameter]
        public List<ClinicModel> Clinics { get; set; } = new List<ClinicModel>();

        protected ClinicModel ClinicToDelete { get; set; }


        protected async Task SetClinicToDeleteAsync(ClinicModel model)
        {
            ClinicToDelete = model;
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ToggleModal, "delete-clinic");
        }

        protected void ClearClinicToDelete()
        {
            ClinicToDelete = null;
        }

        protected async Task DeleteAsync()
        {
            IsLoading = true;

            await ClinicService.DeleteAsync(ClinicToDelete.Id);

            var deletedClinic = Clinics.FirstOrDefault(d => d.Id.Equals(ClinicToDelete.Id));
            Clinics.Remove(deletedClinic);
            ClinicToDelete = null;

            IsLoading = false;
        }
    }
}
