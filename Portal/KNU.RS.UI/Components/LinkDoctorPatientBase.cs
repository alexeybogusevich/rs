using KNU.RS.Logic.Collections;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Services.PatientService;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class LinkDoctorPatientBase : PageBase
    {
        [Inject]
        protected IPatientService PatientService { get; set; }


        [Parameter]
        public Guid DoctorId { get; set; }


        protected int Counter = 1;

        private int PageSize = 10;

        private int PagesForReference = 5;

        public List<PatientShort> Patients { get; set; } = new List<PatientShort>();

        protected List<int> AvailablePages { get; set; } = new List<int>();

        protected PaginatedList<PatientShort> PatientsPage { get; set; } = new PaginatedList<PatientShort>();

        protected Filtering FilteringModel { get; set; } = new Filtering();

        protected bool IsLoading { get; set; }


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            var patients = await PatientService.GetShortAsync(cancellationTokenSource.Token);
            Patients = patients?.OrderBy(p => p.FullName)?.ToList();
            PatientsPage = PaginatedList<PatientShort>.Create(Patients, 1, PageSize);
            SetAvailablePages();

            IsLoading = false;
        }


        protected async Task AssignPatientAsync(Guid patientId)
        {
            await PatientService.AssignToDoctorAsync(patientId, DoctorId);
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
            PatientsPage = PaginatedList<PatientShort>.Create(Patients, pageNumber, PageSize);
            SetAvailablePages();
        }


        protected void Filter()
        {
            if (string.IsNullOrEmpty(FilteringModel.SearchWord))
            {
                PatientsPage = PaginatedList<PatientShort>.Create(Patients, 1, PageSize);
                SetAvailablePages();
                return;
            }

            var filteredPatients = Patients.Where(p =>
                p.FullName.IndexOf(FilteringModel.SearchWord, StringComparison.OrdinalIgnoreCase) >= 0);

            PatientsPage = PaginatedList<PatientShort>.Create(filteredPatients, 1, PageSize);
            SetAvailablePages();
        }


        protected void ClearFilters()
        {
            FilteringModel.SearchWord = string.Empty;
            PatientsPage = PaginatedList<PatientShort>.Create(Patients, 1, PageSize);
            SetAvailablePages();
        }


        protected class Filtering
        {
            public string SearchWord { get; set; }
        }
    }
}
