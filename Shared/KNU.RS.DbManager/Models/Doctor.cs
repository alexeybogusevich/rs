using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KNU.RS.DbManager.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }

        public Guid QualificationId { get; set; }
        [JsonIgnore]
        public Qualification Qualification { get; set; }

        public Guid ClinicId { get; set; }
        [JsonIgnore]
        public Clinic Clinic { get; set; }

        public List<Visit> Visits { get; set; }
    }
}
