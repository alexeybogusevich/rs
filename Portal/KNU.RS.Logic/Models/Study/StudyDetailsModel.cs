using KNU.RS.Logic.Validation;
using System;

namespace KNU.RS.Logic.Models.Study
{
    public class StudyDetailsModel
    {
        [NotEmptyGuid(ErrorMessage = "Будь-ласка, вкажіть ідентифікатор підтипу обстеження.")]
        public Guid StudySubtypeId { get; set; }


        public decimal MinClockwiseDegrees { get; set; }
        public decimal AvgClockwiseDegrees { get; set; }
        public decimal MaxClockwiseDegrees { get; set; }

        public decimal MinCounterClockwiseDegrees { get; set; }
        public decimal AvgCounterClockwiseDegrees { get; set; }
        public decimal MaxCounterClockwiseDegrees { get; set; }
    }
}
