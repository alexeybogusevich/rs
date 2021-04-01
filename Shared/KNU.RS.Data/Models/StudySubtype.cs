using System;
using System.Collections.Generic;

namespace KNU.RS.Data.Models
{
    public class StudySubtype
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid StudyTypeId { get; set; }
        public StudyType StudyType { get; set; }

        public List<StudyDetails> StudyDetails { get; set; }
    }
}
