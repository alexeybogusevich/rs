using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KNU.RS.Data.Models
{
    public class StudyHeader
    {
        public Guid Id { get; set; }

        public decimal? PatientWeight { get; set; }
        public decimal? PatientHeight { get; set; }

        public string Complaints { get; set; }
        public string Diagnosis { get; set; }
        public string Notes { get; set; }
        public decimal Price { get; set; }

        public Guid VisitId { get; set; }
        [JsonIgnore]
        public Visit Visit { get; set; }

        public Guid RecoveryPlanId { get; set; }
        [JsonIgnore]
        public RecoveryPlan RecoveryPlan { get; set; }


        [JsonIgnore]
        public List<StudyDetails> StudyDetails { get; set; }
    }
}
