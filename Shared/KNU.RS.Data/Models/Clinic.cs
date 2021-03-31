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

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<DoctorProfile> Doctors { get; set; }
    }
}
