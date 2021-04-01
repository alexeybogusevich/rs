using System;

namespace KNU.RS.Data.Models
{
    public class StudyDetails
    {
        public Guid Id { get; set; }

        public decimal ClockwiseDegrees { get; set; }
        public decimal CounterClockwiseDegrees { get; set; }

        public Guid StudySubtypeId { get; set; }
        public StudySubtype StudySubtype { get; set; }

        public Guid StudyHeaderId { get; set; }
        public StudyHeader StudyHeader { get; set; }
    }
}
