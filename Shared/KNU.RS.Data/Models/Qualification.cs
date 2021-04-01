using System;
using System.Collections.Generic;

namespace KNU.RS.Data.Models
{
    public class Qualification
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<DoctorProfile> Doctors { get; set; }
    }
}
