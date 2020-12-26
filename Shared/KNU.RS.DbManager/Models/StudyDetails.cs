using System;
using System.Text.Json.Serialization;

namespace KNU.RS.DbManager.Models
{
    public class StudyDetails
    {
        public Guid Id { get; set; }

        public decimal ClockwiseDegrees { get; set; }
        public decimal CounterClockwiseDegrees { get; set; }

        public Guid StudySubtypeId { get; set; }
        [JsonIgnore]
        public StudySubtype StudySubtype { get; set; }

        public Guid StudyHeaderId { get; set; }
        [JsonIgnore]
        public StudyHeader StudyHeader { get; set; }
    }
}
