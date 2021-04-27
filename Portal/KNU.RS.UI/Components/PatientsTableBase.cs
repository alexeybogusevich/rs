using KNU.RS.Logic.Collections;
using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Services.PhotoService;
using KNU.RS.Logic.Services.UserService;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class PatientsTableBase : ComponentBase
    {
        [Inject]
        protected IPhotoService PhotoService { get; set; }

        [Inject]
        protected IUserService UserService { get; set; }

        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }


        [Parameter]
        public List<PatientInfo> Patients { get; set; }


        protected PatientInfo PatientToDelete { get; set; }


        protected int Counter = 1;

        private int PageSize = 10;

        private int PagesForReference = 5;


        protected List<int> AvailablePages { get; set; } = new List<int>();

        protected PaginatedList<PatientInfo> PatientsPage { get; set; }

        protected Filtering FilteringModel { get; set; } = new();


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

        protected void AssignPatientToDelete(PatientInfo patient)
        {
            PatientToDelete = patient;
        }

        protected void ClearPatientToDelete()
        {
            PatientToDelete = null;
        }

        protected async Task DeleteAsync()
        {
            if (PatientToDelete == null)
            {
                return;
            }

            if (PatientToDelete.HasPhoto)
            {
                PhotoService.DeleteAsync(PatientToDelete.UserId);
            }

            await UserService.DeleteAsync(PatientToDelete.UserId);

            var deletedDoctor = Patients.FirstOrDefault(d => d.UserId.Equals(PatientToDelete.UserId));
            Patients.Remove(deletedDoctor);

            PatientsPage = PaginatedList<PatientInfo>.Create(Patients, PatientsPage.PageIndex, PageSize);
            SetAvailablePages();

            PatientToDelete = null;
        }

        protected class Filtering
        {
            public string SearchWord { get; set; }
        }
    }
}
