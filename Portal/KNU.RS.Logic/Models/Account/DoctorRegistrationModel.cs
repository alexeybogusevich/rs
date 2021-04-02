using System;

namespace KNU.RS.Logic.Models.Account
{
    public class DoctorRegistrationModel : RegistrationModel
    {
        public Guid QualificationId { get; set; }
        public Guid ClinicId { get; set; }
    }
}
