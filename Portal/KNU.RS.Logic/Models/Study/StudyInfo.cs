using System;

namespace KNU.RS.Logic.Models.Study
{
    public class StudyInfo
    {
        public Guid Id { get; set; }

        public DateTime DateTime { get; set; }

        public Guid? StudyTypeId { get; set; }
        public string StudyTypeName { get; set; }

        public Guid? StudySubtypeId { get; set; }
        public string StudySubtypeName { get; set; }
    }
}
