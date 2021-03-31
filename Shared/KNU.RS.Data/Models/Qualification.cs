using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KNU.RS.Data.Models
{
    public class Qualification
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<DoctorProfile> Doctors { get; set; }
    }
}
