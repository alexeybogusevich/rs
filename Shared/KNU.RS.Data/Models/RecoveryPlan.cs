using System;
using System.Collections.Generic;

namespace KNU.RS.Data.Models
{
    public class RecoveryPlan
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<StudyHeader> Studies { get; set; }
    }
}
