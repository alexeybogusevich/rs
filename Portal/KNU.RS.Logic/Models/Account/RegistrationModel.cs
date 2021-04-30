using KNU.RS.Data.Enums;
using KNU.RS.Logic.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace KNU.RS.Logic.Models.Account
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Будь-ласка, вкажіть ім'я")]
        [MaxLength(100, ErrorMessage = "Будь-ласка, вкажіть не більше, ніж 100 символів")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Будь-ласка, вкажіть прізвище")]
        [MaxLength(100, ErrorMessage = "Будь-ласка, вкажіть не більше, ніж 100 символів")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Будь-ласка, вкажіть по-батькові")]
        [MaxLength(100, ErrorMessage = "Будь-ласка, вкажіть не більше, ніж 100 символів")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Будь-ласка, вкажіть стать")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Будь-ласка, вкажіть адресу")]
        [MaxLength(200, ErrorMessage = "Будь-ласка, вкажіть не більше, ніж 200 символів")]
        public string Address { get; set; }

        [ValidBirthday(ErrorMessage = "Будь-ласка, вкажіть валідну дату народження")]
        public DateTime Birthday { get; set; } = new DateTime(1982, 12, 31);

        [Required(ErrorMessage = "Будь-ласка, вкажіть поштову адресу")]
        [EmailAddress(ErrorMessage = "Будь-ласка, введіть валідну email адресу")]
        [MaxLength(100, ErrorMessage = "Будь-ласка, вкажіть не більше, ніж 100 символів")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Будь-ласка, вкажіть номер телефону")]
        [Phone(ErrorMessage = "Будь-ласка, введіть валідний номер телефону")]
        [ValidPhoneNumber(ErrorMessage = "Будь-ласка, введіть валідний номер телефону")]
        public string PhoneNumber { get; set; }

        public byte[] Photo { get; set; }
    }
}
