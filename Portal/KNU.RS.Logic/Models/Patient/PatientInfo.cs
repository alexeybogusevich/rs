using KNU.RS.Logic.Models.User;

namespace KNU.RS.Logic.Models.Patient
{
    public class PatientInfo : UserInfo
    {
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public string Description { get; set; }
    }
}
