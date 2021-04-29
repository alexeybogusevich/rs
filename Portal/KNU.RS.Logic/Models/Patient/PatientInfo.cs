using KNU.RS.Data.Enums;
using KNU.RS.Logic.Models.User;
using System;

namespace KNU.RS.Logic.Models.Patient
{
    public class PatientInfo : UserInfo
    {
        public Guid PatientId { get; set; }

        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }

        public MaritalStatus MaritalStatus { get; set; }
        public EducationStatus EducationStatus { get; set; }
        public Occupation Occupation { get; set; }
        public string Job { get; set; }
        public string Position { get; set; }
        public string HealthInsuranse { get; set; }
        public string HealthInsuranseCompany { get; set; }
        public string Passport { get; set; }

        public string Complaints { get; set; }
        public string Diagnosis { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
