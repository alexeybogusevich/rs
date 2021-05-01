using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Helpers;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Models.Study;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class PanelBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }

        [Parameter]
        public List<PatientInfo> Patients { get; set; } = new List<PatientInfo>();

        [Parameter]
        public List<StudyInfo> Studies { get; set; } = new List<StudyInfo>();

        [Parameter]
        public int NumberOfDoctors { get; set; }

        protected string GetPhotoURI(PatientInfo patient)
        {
            if (patient.HasPhoto)
            {
                return $"{StaticFileConstants.PhotosRequestPath}/{patient.UserId}.{Options.Value.Extension}";
            }

            return "img/user.jpg";
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var cultureInfo = CultureInfo.CurrentCulture;
            var groupedStudies = Studies
                .GroupBy(s => (s.DateTime.Year, s.DateTime.Month))
                .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
                .Take(12)
                .Select(g => new
                {
                    Date = $"{DateTimeHelper.GetLocalMonthName(g.Key.Month, cultureInfo)} {g.Key.Year}",
                    Count = g.Count()
                });

            var months = groupedStudies.Select(s => s.Date).ToList();
            var studyCounts = groupedStudies.Select(s => s.Count).ToList();

            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.FillMainBarchart, months, studyCounts, "Проведено");
        }
    }
}
