using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.Doctor;
using KNU.RS.Logic.Services.PhotoService;
using KNU.RS.Logic.Services.UserService;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class DoctorsGridBase : PageBase
    {
        [Inject]
        protected IPhotoService PhotoService { get; set; }

        [Inject]
        protected IUserService UserService { get; set; }

        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }


        [Parameter]
        public List<DoctorInfo> Doctors { get; set; } = new List<DoctorInfo>();

        protected List<DoctorInfo> DisplayedDoctors { get; set; } = new List<DoctorInfo>();

        protected DoctorInfo DoctorToDelete { get; set; }

        private int BatchSize { get; set; } = 8;
        private int Batches { get; set; } = 1;

        protected override void OnParametersSet()
        {
            SetDisplayedDoctors();
        }

        private void SetDisplayedDoctors()
        {
            DisplayedDoctors = Doctors.Take(Batches * BatchSize).OrderBy(d => d.LastName).ToList();
        }

        protected void LoadMore()
        {
            if (DisplayedDoctors.Count == Doctors.Count)
            {
                return;
            }

            Batches++;
            SetDisplayedDoctors();
        }

        protected void AssignDoctorToDelete(DoctorInfo doctor)
        {
            DoctorToDelete = doctor;
        }

        protected void ClearDoctorToDelete()
        {
            DoctorToDelete = null;
        }

        protected async Task DeleteAsync()
        {
            if (DoctorToDelete == null)
            {
                return;
            }

            if (DoctorToDelete.HasPhoto)
            {
                PhotoService.DeleteAsync(DoctorToDelete.UserId);
            }

            await UserService.DeleteAsync(DoctorToDelete.UserId);

            var deletedDoctor = Doctors.FirstOrDefault(d => d.UserId.Equals(DoctorToDelete.UserId));
            Doctors.Remove(deletedDoctor);

            DisplayedDoctors = new List<DoctorInfo>();
            SetDisplayedDoctors();

            DoctorToDelete = null;
        }
    }
}
