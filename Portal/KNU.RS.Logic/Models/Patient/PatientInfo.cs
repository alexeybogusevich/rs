using KNU.RS.Logic.Models.User;

namespace KNU.RS.Logic.Models.Patient
{
    public class PatientInfo : UserInfo
    {
        public string Birthday { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
    }
}
