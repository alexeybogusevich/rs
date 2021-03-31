using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KNU.RS.Data.Models
{
    public class StudySubtype
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid StudyTypeId { get; set; }
        [JsonIgnore]
        public StudyType StudyType { get; set; }

        [JsonIgnore]
        public List<StudyDetails> StudyDetails { get; set; }
    }
}
