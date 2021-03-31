using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KNU.RS.Data.Models
{
    public class Department
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<Clinic> Clinics { get; set; }
    }
}
