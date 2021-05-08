using System;

namespace KNU.RS.Logic.Models.Study
{
    public class StudyDetailsInfo
    {
        public Guid Id { get; set; }
        public int SerialNumber { get; set; }

        public decimal MinClockwiseDegrees { get; set; }
        public decimal AvgClockwiseDegrees { get; set; }
        public decimal MaxClockwiseDegrees { get; set; }

        public decimal MinCounterClockwiseDegrees { get; set; }
        public decimal AvgCounterClockwiseDegrees { get; set; }
        public decimal MaxCounterClockwiseDegrees { get; set; }

        public Guid? StudyHeaderId { get; set; }
        public DateTime? DateTime { get; set; }

        public Guid? StudySubtypeId { get; set; }
        public string StudySubtypeName { get; set; }

        public Guid? StudyTypeId { get; set; }
        public string StudyTypeName { get; set; }
    }
}
