using KNU.RS.Logic.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace KNU.RS.Logic.Models.Clinic
{
    public class ClinicModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Будь-ласка, вкажіть назву відділення.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Будь-ласка, вкажіть номер телефону")]
        [Phone(ErrorMessage = "Будь-ласка, вкажіть валідний номер телефону")]
        [ValidPhoneNumber(ErrorMessage = "Будь-ласка, вкажіть валідний номер телефону")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Будь-ласка, вкажіть адресу відділення.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Будь-ласка, вкажіть робочі години.")]
        public string WorkingHours { get; set; }
    }
}
