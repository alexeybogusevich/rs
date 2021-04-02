using KNU.RS.Logic.Models.User;
using System;

namespace KNU.RS.Logic.Models.Patient
{
    public class PatientInfo : UserInfo
    {
        public DateTime Birthday { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
    }
}
