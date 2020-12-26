using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KNU.RS.DbManager.Models
{
    public class StudyHeader
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }
        public Guid DoctorId { get; set; }
        [JsonIgnore]
        public Doctor Doctor { get; set; }
        public Guid PatientId { get; set; }
        [JsonIgnore]
        public Patient Patient { get; set; }
        public decimal Price { get; set; }

        [JsonIgnore]
        public List<StudyDetails> StudyDetails { get; set; }
    }
}
