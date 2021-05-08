using System;

namespace KNU.RS.Data.Models
{
    public class StudyDetails
    {
        public Guid Id { get; set; }

        public decimal MinClockwiseDegrees { get; set; }
        public decimal AvgClockwiseDegrees { get; set; }
        public decimal MaxClockwiseDegrees { get; set; }

        public decimal MinCounterClockwiseDegrees { get; set; }
        public decimal AvgCounterClockwiseDegrees { get; set; }
        public decimal MaxCounterClockwiseDegrees { get; set; }

        public Guid StudySubtypeId { get; set; }
        public StudySubtype StudySubtype { get; set; }

        public Guid StudyHeaderId { get; set; }
        public StudyHeader StudyHeader { get; set; }
    }
}
