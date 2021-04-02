using System;

namespace KNU.RS.UI.Models.Study
{
    public class StudyInfo
    {
        public Guid Id { get; set; }

        public string Complaints { get; set; }
        public string Diagnosis { get; set; }
        public string Notes { get; set; }

        public Guid StudyTypeId { get; set; }
        public string StudyTypeName { get; set; }

        public Guid StudySubtypeId { get; set; }
        public string StudySubtypeName { get; set; }
    }
}
