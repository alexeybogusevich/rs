namespace KNU.RS.Logic.Models.Study
{
    public class StudyDetailsShort
    {
        public decimal MinClockwiseDegrees { get; set; }
        public decimal AvgClockwiseDegrees { get; set; }
        public decimal MaxClockwiseDegrees { get; set; }

        public decimal MinCounterClockwiseDegrees { get; set; }
        public decimal AvgCounterClockwiseDegrees { get; set; }
        public decimal MaxCounterClockwiseDegrees { get; set; }

        public string StudySubtypeName { get; set; }
    }
}
