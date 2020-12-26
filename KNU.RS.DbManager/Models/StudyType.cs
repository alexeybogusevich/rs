using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KNU.RS.DbManager.Models
{
    public class StudyType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<StudySubtype> StudySubtypes { get; set; }
    }
}
