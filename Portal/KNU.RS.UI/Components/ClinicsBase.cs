using KNU.RS.Logic.Models.Clinic;
using KNU.RS.Logic.Services.ClinicService;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class ClinicsBase : PageBase
    {
        [Inject]
        protected IClinicService ClinicService { get; set; }

        protected List<ClinicModel> ClinicsList { get; set; } = new List<ClinicModel>();

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            var clinics = await ClinicService.GetModelAsync(cancellationTokenSource.Token);
            ClinicsList = clinics?.OrderBy(c => c.Name)?.ToList() ?? new();

            IsLoading = false;
        }
    }
}
