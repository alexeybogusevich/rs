using KNU.RS.Logic.Models.Study;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class StudiesTableBase : PageBase
    {
        [Parameter]
        public List<StudyInfo> Studies { get; set; } = new List<StudyInfo>();


        protected List<StudyDetailsShort> StudyDetailsToDisplay { get; set; } = new List<StudyDetailsShort>();


        protected async Task ShowDetailsAsync(IEnumerable<StudyDetailsShort> studyDetails)
        {
            StudyDetailsToDisplay = studyDetails.ToList();
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ToggleModal, "study-details-modal");
        }

        protected void CloseDetails()
        {
            StudyDetailsToDisplay = new List<StudyDetailsShort>();
        }

        protected void DownloadReport(Guid reportId)
        {
            NavigationManager.NavigateTo($"/api/studyreports/{reportId}", true);
        }
    }
}
