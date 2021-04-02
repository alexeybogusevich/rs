using System;
using System.Collections.Generic;

namespace KNU.RS.Data.Models
{
    public class DoctorPatient
    {
        public Guid Id { get; set; }

        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

        public IEnumerable<RecoveryDailyPlan> RecoveryDailyPlans { get; set; }
    }
}
