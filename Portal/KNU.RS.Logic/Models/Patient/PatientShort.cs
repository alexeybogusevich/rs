using System;
using System.Collections.Generic;

namespace KNU.RS.Logic.Models.Patient
{
    public class PatientShort
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public DateTime? BirthDay { get; set; }

        public IEnumerable<Guid> Doctors { get; set; }
    }
}
