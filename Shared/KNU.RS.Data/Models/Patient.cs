using KNU.RS.Data.Enums;
using System;
using System.Collections.Generic;

namespace KNU.RS.Data.Models
{
    public class Patient
    {
        public Guid Id { get; set; }

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

        public Guid UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<DoctorPatient> Doctors { get; set; }
    }
}
