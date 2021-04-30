using System;

namespace KNU.RS.Logic.Models.Study
{
    public class StudyDetailsInfo
    {
        public Guid Id { get; set; }
        public int SerialNumber { get; set; }

        public decimal ClockwiseDegrees { get; set; }
        public decimal CounterClockwiseDegrees { get; set; }

        public Guid? StudyHeaderId { get; set; }
        public DateTime? DateTime { get; set; }

        public Guid? StudySubtypeId { get; set; }
        public string StudySubtypeName { get; set; }

        public Guid? StudyTypeId { get; set; }
        public string StudyTypeName { get; set; }
    }
}
