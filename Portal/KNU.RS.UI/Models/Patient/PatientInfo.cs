using System;

namespace KNU.RS.UI.Models.Patient
{
    public class PatientInfo
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
    }
}
