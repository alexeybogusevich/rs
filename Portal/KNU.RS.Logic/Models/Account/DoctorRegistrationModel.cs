using KNU.RS.Logic.Validation;
using System;

namespace KNU.RS.Logic.Models.Account
{
    public class DoctorRegistrationModel : RegistrationModel
    {
        [NotEmptyGuid(ErrorMessage = "Будь-ласка, вкажіть посаду")]
        public Guid QualificationId { get; set; }

        [NotEmptyGuid(ErrorMessage = "Будь-ласка, вкажіть відділення")]
        public Guid ClinicId { get; set; }

        public string Biography { get; set; }
    }
}
