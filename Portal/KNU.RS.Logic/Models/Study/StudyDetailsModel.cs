using KNU.RS.Logic.Validation;
using System;

namespace KNU.RS.Logic.Models.Study
{
    public class StudyDetailsModel
    {
        [NotEmptyGuid(ErrorMessage = "Будь-ласка, вкажіть ідентифікатор підтипу обстеження.")]
        public Guid StudySubtypeId { get; set; }

        public decimal ClockwiseDegrees { get; set; }

        public decimal CounterClockwiseDegrees { get; set; }
    }
}
