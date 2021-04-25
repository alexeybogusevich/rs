using System;

namespace KNU.RS.Data.Models
{
    public class Education
    {
        public Guid Id { get; set; }

        public string InstitutionName { get; set; }
        public string Degree { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
