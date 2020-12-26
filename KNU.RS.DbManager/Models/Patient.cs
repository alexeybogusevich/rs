using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KNU.RS.DbManager.Models
{
    public class Patient
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        
        [JsonIgnore]
        public List<StudyHeader> Studies { get; set; }
    }
}
