using System;
using System.Collections.Generic;

namespace KNU.RS.Data.Models
{
    public class StudyHeader
    {
        public Guid Id { get; set; }

        public DateTime DateTime { get; set; }

        public Guid DoctorPatientId { get; set; }
        public DoctorPatient DoctorPatient { get; set; }

        public List<StudyDetails> StudyDetails { get; set; }
    }
}
