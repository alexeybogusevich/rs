using System;

namespace KNU.RS.Logic.Models.Account
{
    public class PatientRegistrationModel : RegistrationModel
    {
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public string Description { get; set; }
    }
}
