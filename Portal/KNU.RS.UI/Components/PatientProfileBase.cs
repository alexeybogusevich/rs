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
    public class PatientProfileBase : ComponentBase
    {
        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }

        [Inject]
        protected IPatientService PatientService { get; set; }

        [Inject]
        protected IStudyService StudyService { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Parameter]
        public PatientInfo Patient { get; set; }

        protected List<StudyDetailsInfo> Studies { get; set; } = new List<StudyDetailsInfo>();

        protected override async Task OnInitializedAsync()
        {
            var studies = await StudyService.GetDetailsInfoAsync(Patient.PatientId);
            Studies = studies.OrderBy(s => s.DateTime).ToList();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var groupedStudies = Studies.GroupBy(s => new { s.SerialNumber, Name = s.StudySubtypeName });

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
                    ChartConstants.ClockwiseDegreesTitle, ChartConstants.CounterClockwiseDegreesTitle, 
                    clockwiseStudies, counterClockwiseStudies, studiesOfSubtype.Key.SerialNumber);
            }
        }

        protected string GetPhotoURI()
        {
            if (Patient.HasPhoto)
            {
                return $"{StaticFileConstants.PhotosRequestPath}/{Patient.UserId}.{Options.Value.Extension}";
            }

            return "img/user.jpg";
        }
    }
}
