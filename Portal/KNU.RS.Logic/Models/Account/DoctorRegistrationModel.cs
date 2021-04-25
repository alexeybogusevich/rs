using KNU.RS.Logic.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace KNU.RS.Logic.Models.Account
{
    public class DoctorRegistrationModel : RegistrationModel
    {
        [NotEmptyGuid(ErrorMessage = "Будь-ласка, вкажіть посаду")]
        public Guid QualificationId { get; set; }

        [NotEmptyGuid(ErrorMessage = "Будь-ласка, вкажіть відділення")]
        public Guid ClinicId { get; set; }

        [MaxLength(500, ErrorMessage = "Будь-ласка, введіть не більше, ніж 500 символів")]
        public string Biography { get; set; }

        [MaxLength(500, ErrorMessage = "Будь-ласка, введіть не більше, ніж 500 символів")]
        [Required(ErrorMessage = "Будь-ласка, вкажіть професійні компетенції")]
        public string Competencies { get; set; }

        [MaxLength(100, ErrorMessage = "Будь-ласка, введіть не більше, ніж 100 символів")]
        [Required(ErrorMessage = "Будь-ласка, вкажіть науковий ступінь")]
        public string Degree { get; set; }
        
        [PositiveInt(ErrorMessage = "Будь-ласка, вкажіть валідний номер аудиторії")]
        public int Room { get; set; }
    }
}
