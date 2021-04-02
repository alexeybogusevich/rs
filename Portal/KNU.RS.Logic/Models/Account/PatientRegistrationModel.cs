using System;

namespace KNU.RS.Logic.Models.Account
{
    public class PatientRegistrationModel : RegistrationModel
    {
        public DateTime BirthDay { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
    }
}
