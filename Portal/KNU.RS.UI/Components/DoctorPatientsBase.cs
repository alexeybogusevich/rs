using KNU.RS.Logic.Collections;
using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Services.PatientService;
using KNU.RS.Logic.Services.PhotoService;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class DoctorPatientsBase : PageBase
    {
        [Inject]
        protected IPhotoService PhotoService { get; set; }

        [Inject]
        protected IPatientService PatientService { get; set; }

        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }

        [Parameter]
        public Guid DoctorId { get; set; }

        [Parameter]
        public List<PatientInfo> Patients { get; set; }


        protected int Counter = 1;

        private int PageSize = 10;

        private int PagesForReference = 5;


        protected List<int> AvailablePages { get; set; } = new List<int>();

        protected PaginatedList<PatientInfo> PatientsPage { get; set; }

        protected Filtering FilteringModel { get; set; } = new();


        protected async Task RefreshPatientsAsync()
        {
            IsLoading = true;

            var patients = await PatientService.GetInfoByDoctorAsync(DoctorId, cancellationTokenSource.Token);
            Patients = patients.ToList();
            PatientsPage = PaginatedList<PatientInfo>.Create(Patients, 1, PageSize);
            SetAvailablePages();

            IsLoading = false;
        }

        protected override void OnParametersSet()
        {
            PatientsPage = PaginatedList<PatientInfo>.Create(Patients, 1, PageSize);
            SetAvailablePages();
        }

        protected async Task ToggleModalAsync()
        {
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ToggleModal, "doctor-patients-modal");
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

        protected void Filter()
        {
            if (string.IsNullOrEmpty(FilteringModel.SearchWord))
            {
                PatientsPage = PaginatedList<PatientInfo>.Create(Patients, 1, PageSize);
                SetAvailablePages();
                return;
            }

            var filteredPatients = Patients.Where(p =>
                p.FirstName.IndexOf(FilteringModel.SearchWord, StringComparison.OrdinalIgnoreCase) >= 0 ||
                p.LastName.IndexOf(FilteringModel.SearchWord, StringComparison.OrdinalIgnoreCase) >= 0 ||
                p.MiddleName.IndexOf(FilteringModel.SearchWord, StringComparison.OrdinalIgnoreCase) >= 0);

            PatientsPage = PaginatedList<PatientInfo>.Create(filteredPatients, 1, PageSize);
            SetAvailablePages();
        }

        protected void ClearFilters()
        {
            FilteringModel.SearchWord = string.Empty;
            PatientsPage = PaginatedList<PatientInfo>.Create(Patients, 1, PageSize);
            SetAvailablePages();
        }

        protected class Filtering
        {
            public string SearchWord { get; set; }
        }
    }
}
