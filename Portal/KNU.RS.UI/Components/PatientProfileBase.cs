using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Models.Study;
using KNU.RS.Logic.Services.PatientService;
using KNU.RS.Logic.Services.StudyService;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class PatientProfileBase : PageBase
    {
        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }

        [Inject]
        protected IPatientService PatientService { get; set; }

        [Inject]
        protected IStudyService StudyService { get; set; }


        [Parameter]
        public PatientInfo Patient { get; set; }

        protected List<StudyInfo> Studies { get; set; } = new List<StudyInfo>();

        protected List<StudyDetailsInfo> StudyDetails { get; set; } = new List<StudyDetailsInfo>();


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            var studyDetails = await StudyService.GetDetailsInfoAsync(Patient.Id, cancellationTokenSource.Token);
            StudyDetails = studyDetails.OrderBy(s => s.DateTime).Take(15).ToList();

            var studies = await StudyService.GetInfoAsync(Patient.Id, cancellationTokenSource.Token);
            Studies = studies.OrderByDescending(s => s.DateTime).ToList();

            IsLoading = false;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (Studies.Count < 2)
            {
                return;
            }

            if (!firstRender)
            {
                return;
            }

            var groupedStudies = StudyDetails.GroupBy(s => new { s.SerialNumber, Name = s.StudySubtypeName });

            foreach (var studiesOfSubtype in groupedStudies)
            {
                var typeName = studiesOfSubtype.FirstOrDefault()?.StudyTypeName;
                var title = $"{typeName} : {studiesOfSubtype.Key.Name}";

                var clockwiseStudies = studiesOfSubtype.Select(s => s.ClockwiseDegrees).ToList();
                var counterClockwiseStudies = studiesOfSubtype.Select(s => s.CounterClockwiseDegrees).ToList();

                var labels = studiesOfSubtype.Select(s => s.DateTime.GetValueOrDefault().ToString("dd.MM.yyyy")).ToList();

                await JsRuntime.InvokeVoidAsync(
                    JSExtensionMethods.FillStudyLinechart,
                    title, labels,
                    Labels.ClockwiseDegreesTitle, Labels.CounterClockwiseDegreesTitle,
                    clockwiseStudies, counterClockwiseStudies, studiesOfSubtype.Key.SerialNumber);
            }
        }
    }
}
