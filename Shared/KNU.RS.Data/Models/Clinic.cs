using System;
using System.Collections.Generic;

namespace KNU.RS.Data.Models
{
    public class Clinic
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string WorkingHours { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}
