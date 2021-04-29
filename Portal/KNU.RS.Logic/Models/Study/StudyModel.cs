using KNU.RS.Logic.Validation;
using System;
using System.Collections.Generic;

namespace KNU.RS.Logic.Models.Study
{
    public class StudyModel
    {
        [NotEmptyGuid(ErrorMessage = "Будь-ласка, вкажіть ідентифікатор пацієнта.")]
        public Guid PatientId { get; set; }

        public IEnumerable<StudyDetailsModel> StudyDetails { get; set; }
    }
}
