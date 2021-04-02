using System;
using System.Collections.Generic;

namespace KNU.RS.Data.Models
{
    public class Patient
    {
        public Guid Id { get; set; }

        public DateTime Birthday { get; set; }

        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<DoctorPatient> Doctors { get; set; }
    }
}
