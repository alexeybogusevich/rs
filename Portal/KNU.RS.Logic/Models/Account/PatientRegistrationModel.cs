using KNU.RS.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace KNU.RS.Logic.Models.Account
{
    public class PatientRegistrationModel : RegistrationModel
    {
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public EducationStatus EducationStatus { get; set; }

        public Occupation Occupation { get; set; }
        public string Job { get; set; }
        public string Position { get; set; }

        public string HealthInsuranse { get; set; }
        public string HealthInsuranseCompany { get; set; }

        [Required(ErrorMessage = "Будь-ласка, вкажіть документ, що посвідчує особу")]
        public string Passport { get; set; }

        public string Complaints { get; set; }
        public string Diagnosis { get; set; }
    }
}
