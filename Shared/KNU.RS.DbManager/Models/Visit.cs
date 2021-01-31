using Newtonsoft.Json;
using System;

namespace KNU.RS.DbManager.Models
{
    public class Visit
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public bool Completed { get; set; }

        public Guid DoctorId { get; set; }
        [JsonIgnore]
        public DoctorProfile Doctor { get; set; }

        public Guid PatientId { get; set; }
        [JsonIgnore]
        public PatientProfile Patient { get; set; }

        public StudyHeader Study { get; set; } 
    }
}
