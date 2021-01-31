using System;
using System.Collections.Generic;

namespace KNU.RS.DbManager.Models
{
    public class PatientProfile
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }

        public List<Visit> Visits { get; set; }
    }
}
