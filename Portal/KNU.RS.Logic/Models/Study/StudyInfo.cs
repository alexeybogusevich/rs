using System;
using System.Collections.Generic;

namespace KNU.RS.Logic.Models.Study
{
    public class StudyInfo
    {
        public Guid Id { get; set; }

        public DateTime DateTime { get; set; }

        public Guid DoctorId { get; set; }
        public string DoctorFullName { get; set; }

        public Guid? StudyTypeId { get; set; }
        public string StudyTypeName { get; set; }

        public IEnumerable<StudyDetailsShort> StudyDetails { get; set; }
    }
}
