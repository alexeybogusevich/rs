using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Services.PatientService;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class PatientsBase : ComponentBase
    {
        [Inject]
        protected IPatientService PatientService { get; set; }


        protected List<PatientInfo> PatientsList { get; set; }

        protected bool IsLoading { get; set; } = true;


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            var patients = await PatientService.GetInfoAsync();
            PatientsList = patients.ToList();
            IsLoading = false;
        }
    }
}
