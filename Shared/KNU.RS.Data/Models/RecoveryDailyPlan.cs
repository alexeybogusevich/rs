using System;

namespace KNU.RS.Data.Models
{
    public class RecoveryDailyPlan
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
        public int Times { get; set; }

        public DateTime Day { get; set; }

        public bool Completed { get; set; }

        public Guid DoctorPatientId { get; set; }
        public DoctorPatient DoctorPatient { get; set; }
    }
}
