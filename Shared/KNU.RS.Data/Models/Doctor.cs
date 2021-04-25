using System;
using System.Collections.Generic;

namespace KNU.RS.Data.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }

        public Guid QualificationId { get; set; }
        public Qualification Qualification { get; set; }

        public Guid ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public int Room { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public string Degree { get; set; }
        public string Biography { get; set; }
        public string Competencies { get; set; }

        public IEnumerable<DoctorPatient> Patients { get; set; }
        public IEnumerable<Education> Educations { get; set; }
    }
}
