using KNU.RS.Logic.Collections;
using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace KNU.RS.UI.Components
{
    public class PatientsTableBase : ComponentBase
    {
        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }


        [Parameter]
        public List<PatientInfo> Patients { get; set; }

        protected PaginatedList<PatientInfo> PatientsPage { get; set; }


        protected int Counter = 1;

        private int PageSize = 1;
        private int PagesForReference = 5;

        protected List<int> AvailablePages { get; set; } = new List<int>();

        protected override void OnParametersSet()
        {
            PatientsPage = PaginatedList<PatientInfo>.Create(Patients, 1, PageSize);
            SetAvailablePages();
        }

        protected void SetAvailablePages()
        {
            var resultPages = new List<int>();

            if (PatientsPage.HasPreviousPage)
            {
                resultPages.Add(PatientsPage.PageIndex - 1);
            }

            for (int i = PatientsPage.PageIndex; i <= PatientsPage.TotalPages && resultPages.Count < PagesForReference; ++i)
            {
                resultPages.Add(i);
            }

            AvailablePages = resultPages;
        }

        protected void GoToPage(int pageNumber)
        {
            PatientsPage = PaginatedList<PatientInfo>.Create(Patients, pageNumber, PageSize);
            SetAvailablePages();
        }

        protected string GetPhotoURI(PatientInfo patient)
        {
            if (patient.HasPhoto)
            {
                return $"{StaticFileConstants.PhotosRequestPath}/{patient.UserId}.{Options.Value.Extension}";
            }

            return "img/user.jpg";
        }
    }
}
