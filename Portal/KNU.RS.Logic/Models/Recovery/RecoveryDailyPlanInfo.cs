using System;

namespace KNU.RS.Logic.Models.Recovery
{
    public class RecoveryDailyPlanInfo
    {
        public Guid Id { get; set; }

        public int SerialNumber { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Times { get; set; }

        public DateTime DateTime { get; set; }

        public bool Completed { get; set; }

        public string DoctorName { get; set; }

        public Guid? DoctorId { get; set; }
    }
}
