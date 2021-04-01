using System;
using System.Collections.Generic;

namespace KNU.RS.Data.Models
{
    public class DoctorProfile
    {
        public Guid Id { get; set; }

        public Guid QualificationId { get; set; }
        public Qualification Qualification { get; set; }

        public Guid ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public List<Visit> Visits { get; set; }
    }
}
