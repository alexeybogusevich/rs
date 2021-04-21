using KNU.RS.Logic.Models.User;
using System;

namespace KNU.RS.Logic.Models.Doctor
{
    public class DoctorInfo : UserInfo
    {
        public Guid? QualificationId { get; set; }
        public string QualificationName { get; set; }
        public Guid? ClinicId { get; set; }
        public string Biography { get; set; }
        public string ClinicName { get; set; }
        public string ClinicAddress { get; set; }
        public string ClinicPhoneNumber { get; set; }
    }
}
